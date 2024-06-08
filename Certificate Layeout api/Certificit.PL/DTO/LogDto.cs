using System;

namespace Certificit.PL.DTO
{
    public class LogDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime? DataTime { get; set; } =  DateTime.Now;

        public string Note { get; set; }

        public string Email { get; set; }
    }
}
