using Microsoft.AspNetCore.Http;
using System.IO;

namespace Certificit.PL.DTO
{
    public class ImageUploadRequest
    {
        public string RequestNumber { get; set; }
        public IFormFile Image { get; set; }
        public long Numberofcopies { get; set; } = 1;

    }
}
