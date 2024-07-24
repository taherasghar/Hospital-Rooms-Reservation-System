using Hospital.DTOs;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.IRepository
{
   public interface IUserRepository
    {
        Task <User?> CreateNewUserAsync(NewUserDTO newUser);
        Task <IEnumerable<User>> GetAllUsersAsync();
        Task <UserDTO> AuthenticateUserAsync(string username,string password);

    }
}
