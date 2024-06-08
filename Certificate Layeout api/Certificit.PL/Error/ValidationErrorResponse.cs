using System.Collections.Generic;

namespace Certificit.PL.Error
{
    public class ValidationErrorResponse :ApiResponse
    {
        public List<string> Errors { get; set; }
        public ValidationErrorResponse() : base(400) { }

    }
}
