using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTOs
{
    public class CloseReservationDTO
    {
        public Guid ReservationId { get; set; }
        public DateTime ExitDate { get; set; }
        public Guid ClosedBy { get; set; }

    }
}
