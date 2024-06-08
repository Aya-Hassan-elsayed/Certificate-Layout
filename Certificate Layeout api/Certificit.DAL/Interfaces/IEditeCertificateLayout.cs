using Certificit.DAL.Entities;
using Certificit.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Interfaces
{
    public interface IEditeCertificateLayout
    {
        public Task<IEnumerable<CertificateViewLayoutEdit>> GetAll();
        public Task<CertificateViewLayoutEdit?> GetByShipingOdeder(int ShipingOdeder);
        public Task<IEnumerable<CertificateViewLayoutEdit>> GetAllWithPram(ISpecification<CertificateViewLayoutEdit> specification);
        public Task<int> GetTotalIteamCount(ISpecification<CertificateViewLayoutEdit> specification);
    }
}
