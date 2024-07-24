using Hospital.DTOs;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repository.IRepository
{
    public interface IReservationRepository
    {      
        Task<IEnumerable<Reservation>> GetAllActiveReservationsAsync();
        Task<IEnumerable<Reservation>> GetAllClosedReservationsAsync();
        Task<IEnumerable<Reservation>> GetAllReservationsByDoctorIdAsync(Guid DoctorId);
        Task<Reservation?> CreateNewReservationAsync(newReservationDTO newReservation);
        Task<Reservation?> CloseReservationAsync(CloseReservationDTO closeReservation);



    }
}
