using Certificit.BLL.Interfaces;
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
    public class EditCertificateViewLayoutRepository : IEditeCertificateLayout
    {
        public RSCContext RSCContext { get; }
        public EditCertificateViewLayoutRepository(RSCContext rSCContext)
        {
            RSCContext = rSCContext;
        }


        public async Task<IEnumerable<CertificateViewLayoutEdit>> GetAll()
            => await RSCContext.CertificateViewLayoutEdits.Take(5).ToListAsync();

        public async Task<CertificateViewLayoutEdit?> GetByShipingOdeder(int ShipingOdeder)
            => await RSCContext.CertificateViewLayoutEdits.Where(I => I.IdShippingorder == ShipingOdeder).FirstOrDefaultAsync();

        public async Task<IEnumerable<CertificateViewLayoutEdit>> GetAllWithPram(ISpecification<CertificateViewLayoutEdit> specification)
        {
            // Assuming ApplaySpecfication applies the specifications to the queryable source
            var queryable = await ApplaySpecfication(specification);

            // Projecting only the required properties and converting to a list
            return await queryable.Select(C => new CertificateViewLayoutEdit
            {
                Id = C.Id,
                Requestnumber = C.Requestnumber,
                Name = C.Name,
                Unittype = C.Unittype,
                Geom = C.Geom,
                IdShippingorder = C.IdShippingorder,
                // Add other properties here if needed
            }).AsNoTracking().ToListAsync();
        }




        public async Task<int> GetTotalIteamCount(ISpecification<CertificateViewLayoutEdit> specification)
            => await SpecificationEvaluaterCount<CertificateViewLayoutEdit>.GetQuery(RSCContext.CertificateViewLayoutEdits, specification).CountAsync();

        private async Task<IQueryable<CertificateViewLayoutEdit>> ApplaySpecfication(ISpecification<CertificateViewLayoutEdit> spec)
        {
            return SpecificationEvaluater<CertificateViewLayoutEdit>.GetQuery(RSCContext.CertificateViewLayoutEdits, spec);
        }


    }
}