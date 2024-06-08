using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Specification
{
    public class SpecificationPrams
    {
        public string? RequestNumber { get; set; }
        public string? Name { get; set; }
        public string? UniteType { get; set; }
        //private DateTime? printDate;

        //public DateTime? PrintDate
        //{
        //    get { return printDate?.ToUniversalTime(); }
        //    set { printDate = value; }
        //}
        //public string PrintStatus { get; set; }

        private int pageSize;

        public int PageSize
        {
            get { return pageSize == 0 ? 10 : pageSize; }
            set { pageSize = value <= 7 ? 7 : value; }
        }
        public int PageIndex { get; set; } = 1;
        public int SurveyReview { get; set; } = 0;
    }
}
