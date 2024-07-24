using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTOs
{
    public class NewRoomDTO
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public RoomType Type { get; set; }
        public int Capacity { get; set; }
    }
}
