using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public DateTime? ExitDate { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; } 
        [Required]
        public Guid BedId { get; set; }
        [ForeignKey("BedId")]
        public Bed? Bed { get; set; }

        [Required]
        public Guid DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        [Required]
        public Guid ReservedBy { get; set; }
        [ForeignKey("ReservedBy")]
        public User? ReservedByUser { get; set; }
        public bool isClosed { get; set; } = false;
        [Required]
        public Guid ClosedBy { get; set; }
        [ForeignKey("ClosedBy")]
        public User? ClosedByUser { get; set; }
    }
}
