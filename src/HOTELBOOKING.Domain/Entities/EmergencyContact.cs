using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Domain.Entities
{
    public class EmergencyContact
    {
        public int? EmergencyContactId { get; set; }
        public int? ReservationId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }

       
    }

}
