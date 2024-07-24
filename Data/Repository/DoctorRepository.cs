using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Data.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _db;

        public DoctorRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _db.Doctors.Include(d => d.User).ToListAsync();

        }
        public async Task<Guid> GetDoctorIdByUserId(Guid UserId)
        {

            var doctor = _db.Doctors.FirstOrDefault(d => d.UserId == UserId);
            return doctor.Id;
        }
    }
  }
