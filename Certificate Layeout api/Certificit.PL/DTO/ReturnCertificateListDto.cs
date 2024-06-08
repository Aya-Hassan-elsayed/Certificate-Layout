using Certificit.DAL.Entities;
using System.Collections.Generic;

namespace Certificit.PL.DTO
{
    public class ReturnCertificateListDto
    {
        public List<ReturnListDto> certificateList { get; set; } = new List<ReturnListDto>();
        public PageInfoDetiles  PageInfo { get; set; }
    }
}
