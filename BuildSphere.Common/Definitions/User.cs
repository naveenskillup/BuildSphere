using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Common.Interfaces;

namespace BuildSphere.Common.Definitions
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }   
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Village { get; set; }
        public UserRoles Role { get; set; } 
    }

    public enum UserRoles
    {
        Helper, //Labour
        Mason, //Mestri
        Driver,
        Supervisor,
        Builder,
        Admin
    }
}
