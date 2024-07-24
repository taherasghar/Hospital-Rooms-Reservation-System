using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _db;
        public PatientRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task <Patient> CreateNewPatientAsync(NewPatientDTO newPatient)
        {                
            Patient patient = new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = newPatient.FirstName,
                    LastName = newPatient.LastName,
                    DateOfBirth = newPatient.DateOfBirth,
                    Gender = newPatient.Gender,
                   
                };

            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();

            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _db.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Patient>> GetPatientsWithNoActiveReservationsAsync()
        {
            var patientsWithNoActiveReservations = await _db.Patients
          .Where(patient => !_db.Reservations
              .Any(reservation => reservation.PatientId == patient.Id && !reservation.isClosed))
          .ToListAsync();

            return patientsWithNoActiveReservations;
        }
    }
}
