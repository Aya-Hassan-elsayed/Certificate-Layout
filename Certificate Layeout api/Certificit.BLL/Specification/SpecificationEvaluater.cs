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
    public class SpecificationEvaluater<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Cariteria != null)
                query = query.Where(specification.Cariteria);

            // Pagination should be applied after filtering
            if (specification.IsPagenationEnable)
                query = query.Skip(specification.Skip).Take(specification.Take);

            return query;
        }

    }
}
