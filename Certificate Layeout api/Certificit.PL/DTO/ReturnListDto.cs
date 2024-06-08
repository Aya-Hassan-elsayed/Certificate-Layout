using System;

namespace Certificit.PL.DTO
{
    public class ReturnListDto
    {
        public int Id { get; set; }
        public int IdShippingorder { get; set; }
        public string Requestnumber { get; set; }
        public string Name { get; set; }
        public string Unittype { get; set; }
        public string Geom { get; set; }

    }
}
