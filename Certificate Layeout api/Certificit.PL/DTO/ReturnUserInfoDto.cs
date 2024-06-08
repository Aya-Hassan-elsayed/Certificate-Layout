﻿using System.Collections.Generic;

namespace Certificit.PL.DTO
{
    public class ReturnUserInfoDto
    {
        public string id { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

    }
}
