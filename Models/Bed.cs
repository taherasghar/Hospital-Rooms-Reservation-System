using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Bed
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public bool IsOccupied { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

    }
}
