using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{

    public enum RoomType
    {
        Private = 1,
        Shared = 2,
    }
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        [EnumDataType(typeof(RoomType))]
        public RoomType Type { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
