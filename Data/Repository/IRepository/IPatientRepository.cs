using Hospital.DTOs;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repository.IRepository
{
    public interface IPatientRepository
    {
         Task<Patient> CreateNewPatientAsync(NewPatientDTO newPatient);
        Task<IEnumerable<Patient>> GetPatientsWithNoActiveReservationsAsync();
         Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
}
