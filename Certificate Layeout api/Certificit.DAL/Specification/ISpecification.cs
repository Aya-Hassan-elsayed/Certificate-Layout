using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.DAL.Specification
{
    public interface ISpecification<T> where T : class
    {
        public Expression<Func<T,bool>> Cariteria { get; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagenationEnable { get; set; }
    }
}
