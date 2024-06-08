using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.DAL.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}
