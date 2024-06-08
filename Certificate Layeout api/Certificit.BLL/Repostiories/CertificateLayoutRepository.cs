using Certificit.BLL.Interfaces;
using Certificit.BLL.Specification;
using Certificit.BLL.Specifications;
using Certificit.DAL.Entities;
using Certificit.DAL.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Repositories
{
    public class CertificateLayoutRepository : ICertificateLayout
    {
        public RSCContext RSCContext { get; }
        public CertificateLayoutRepository(RSCContext rSCContext)
        {
            RSCContext = rSCContext;
        }


        public async Task<IEnumerable<CertificateViewLayout33>> GetAll()
            => await RSCContext.CertificateViewLayout33s.Take(5).ToListAsync();

        public async Task<CertificateViewLayout33?> GetByRequestNumber(string RequestNumber)
            => await RSCContext.CertificateViewLayout33s.Where(I => I.Requestnumber == RequestNumber).FirstOrDefaultAsync();

        public async Task<IEnumerable<CertificateViewLayout33>> GetAllWithPram(ISpecification<CertificateViewLayout33> specification)
        {
            // Assuming ApplaySpecfication applies the specifications to the queryable source
            var queryable = await ApplaySpecfication(specification);

            // Projecting only the required properties and converting to a list
            return await queryable.Select(C => new CertificateViewLayout33
            {
                Requestnumber = C.Requestnumber,
                Name = C.Name,
                Unittype = C.Unittype,
                Geom = C.Geom,
                // Add other properties here if needed
            }).AsNoTracking().ToListAsync();
        }




        public async Task<int> GetTotalIteamCount(ISpecification<CertificateViewLayout33> specification)
            => await SpecificationEvaluaterCount<CertificateViewLayout33>.GetQuery(RSCContext.CertificateViewLayout33s, specification).CountAsync();

        private async Task<IQueryable<CertificateViewLayout33>> ApplaySpecfication(ISpecification<CertificateViewLayout33> spec)
        {
            return SpecificationEvaluater<CertificateViewLayout33>.GetQuery(RSCContext.CertificateViewLayout33s, spec);
        }


    }
}
