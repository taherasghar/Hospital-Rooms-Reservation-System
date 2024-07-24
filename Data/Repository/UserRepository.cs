using Hospital.Data.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repository
{
    class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserDTO> AuthenticateUserAsync(string username, string password)
        {
            User? user =  _db.Users.FirstOrDefault(u => u.Username == username);
            if (user == null || user?.Password != password)
            {
                return null;
            }

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userDTO;
        }

        public async Task <User?> CreateNewUserAsync(NewUserDTO newUser)
        {
            User? existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == newUser.Username.ToLower());

            if (existingUser == null)
            {
                User user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = newUser.Username,
                    Password = newUser.Password,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Role = newUser.Role,
                };

                await _db.Users.AddAsync(user);
                if (newUser.Role == UserRole.Doctor)
                {
                    if (string.IsNullOrWhiteSpace(newUser.Specialization))
                    {
                        throw new ArgumentException("Specialization is required for Doctor role.");
                    }
                    Doctor doctor = new Doctor
                    {
                        Id = Guid.NewGuid(),
                        Specialization = newUser.Specialization,
                        UserId = user.Id,
                        User = user
                    };

                    await _db.Doctors.AddAsync(doctor);

                }
                await _db.SaveChangesAsync();
                return user;
            }
            return null;           
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
       
            List<User> users = await _db.Users.ToListAsync();

            return users;
        }
    }
}
