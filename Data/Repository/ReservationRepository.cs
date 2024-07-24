using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _db;

        public ReservationRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Reservation?> CreateNewReservationAsync(newReservationDTO reservationDto)
        {

            var doctor = await _db.Doctors
                .Include(d => d.User) 
                .FirstOrDefaultAsync(d => d.Id == reservationDto.DoctorId);
            var patient = await _db.Patients
                .FirstOrDefaultAsync(p => p.Id == reservationDto.PatientId);
            var bed = await _db.Beds
                .FirstOrDefaultAsync(b => b.Id == reservationDto.BedId);
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Id == reservationDto.ReservedBy);
            if (user == null || bed == null || bed.IsOccupied || patient == null 
                || doctor == null ||  user.Role == UserRole.Doctor  )
                return null;

            // Check for existing reservation for the same patient with a null ExitDate
            var existingReservation = await _db.Reservations
                .FirstOrDefaultAsync(r => r.PatientId == reservationDto.PatientId && r.ExitDate == null);

            if (existingReservation != null)
            {
                return null;
            }
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                EntryDate = reservationDto.EntryDate,
                ExitDate = DateTime.MinValue,
                PatientId = reservationDto.PatientId,
                BedId = reservationDto.BedId,
                DoctorId = reservationDto.DoctorId,
                ReservedBy = reservationDto.ReservedBy,
                ClosedByUser = null,
                isClosed = false,
            };
           

            await _db.Reservations.AddAsync(reservation);
            bed.IsOccupied = true;
            _db.Beds.Update(bed);
            await _db.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation?> CloseReservationAsync(CloseReservationDTO closeReservation)
        {
            var reservation = await _db.Reservations
                .Include(r => r.Bed)
                .FirstOrDefaultAsync(r => r.Id == closeReservation.ReservationId && r.isClosed == false);
            if (reservation == null)
                return null;
            if (closeReservation.ExitDate < reservation.EntryDate)
                return null;

            reservation.ExitDate = closeReservation.ExitDate;
            reservation.isClosed = true;
            reservation.ClosedBy = closeReservation.ClosedBy;

            var bed = reservation.Bed;
            if (bed != null)
            {
                bed.IsOccupied = false;
                _db.Beds.Update(bed);
            }

            _db.Reservations.Update(reservation);
            await _db.SaveChangesAsync();

            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllActiveReservationsAsync()
        {
           
            var activeReservations = new List<Reservation>();
            if (!await _db.Reservations.AnyAsync(r => r.isClosed == false))
                return Enumerable.Empty<Reservation>();

          activeReservations = await _db.Reservations
         .Where(r => r.isClosed == false)
         .Include(r => r.Patient)
         .Include(r => r.Bed)
             .ThenInclude(b => b.Room)
         .Include(r => r.Doctor)
             .ThenInclude(d => d.User)
         .Include(r => r.ReservedByUser)
         .ToListAsync();

            return activeReservations;
        }

        public async Task<IEnumerable<Reservation>> GetAllClosedReservationsAsync()
        {
            var closedReservations = new List<Reservation>();
        
            if (!await _db.Reservations.AnyAsync(r => r.isClosed == true))
                return Enumerable.Empty<Reservation>();

          closedReservations = await _db.Reservations
         .Where(r => r.isClosed == true)
         .Include(r => r.Patient)
         .Include(r => r.Bed)
             .ThenInclude(b => b.Room)
         .Include(r => r.Doctor)
             .ThenInclude(d => d.User)
         .Include(r => r.ReservedByUser)
         .Include(r => r.ClosedByUser)
         .ToListAsync();

            return closedReservations;
        }


        public async Task<IEnumerable<Reservation>> GetAllReservationsByDoctorIdAsync(Guid doctorId)
        {
            var reservations = new List<Reservation>();

            var doctorExists = await _db.Doctors.FirstOrDefaultAsync(r => r.UserId == doctorId);
            if (doctorExists == null)
                return Enumerable.Empty<Reservation>();

            reservations =  await _db.Reservations
                .Where(r => r.DoctorId == doctorExists.Id && r.isClosed != true)
                .Include(r => r.Patient)
                .Include(r => r.Bed)
                .ThenInclude(b => b.Room)        
                .Include(r => r.Doctor)
                .ThenInclude(d => d.User)
                .ToListAsync();

            return reservations;
        }
    }
}
