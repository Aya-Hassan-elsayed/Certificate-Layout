using Certificit.BLL.Specification;
using Certificit.DAL.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Specifications
{
    public class SpecificationEvaluaterCount<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity> spec)
        {
            var Query = InputQuery;

            
            if (spec.Cariteria != null)
                Query = Query.Where(spec.Cariteria);

            return Query;
        }
    }
}
