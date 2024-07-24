using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTOs
{
    public class RoomWithBedsDTO
    {
        public Room Room { get; set; }
        public List<Bed> Beds { get; set; }
    }
}
