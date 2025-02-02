using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Domain.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? StateName { get; set; }
        public int? State { get; set; }

        public DateTime? AuditCreateDate { get; set; }

    }
}
