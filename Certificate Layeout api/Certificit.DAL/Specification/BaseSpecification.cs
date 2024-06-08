using System.Linq.Expressions;

namespace Certificit.DAL.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Cariteria { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagenationEnable { get; set; }
        public BaseSpecification(Expression<Func<T,bool>> expression)
        {
            this.Cariteria = expression;
        }
        public void ApplaySpecificatiion(int take, int skip)
        {
            this.IsPagenationEnable = true;
            this.Take = take;
            this.Skip = skip;
        }
    }
}