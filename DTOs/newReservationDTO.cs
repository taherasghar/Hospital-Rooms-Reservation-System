using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTOs
{
    public class newReservationDTO
    {
        public DateTime EntryDate { get; set; }
        public Guid PatientId { get; set; }
        public Guid BedId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ReservedBy { get; set; }
    }
}
