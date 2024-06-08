namespace Certificit.PL.DTO
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string token { get; set; }
    }
}
