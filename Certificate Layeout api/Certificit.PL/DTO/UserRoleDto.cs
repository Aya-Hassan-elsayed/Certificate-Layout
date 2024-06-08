using System.Collections.Generic;

namespace Certificit.PL.DTO
{
    public class UserRoleDto
    {
        public string id { get; set; }
        public List<string> roles  { get; set; } = new List<string>();  
    }
}
