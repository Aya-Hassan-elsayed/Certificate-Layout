using Certificit.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.DAL.Interfaces
{
    public interface ITokenServices
    {
        public Task<string> GenerateToken(AppUser user , UserManager<AppUser> userManager);
    }
}
