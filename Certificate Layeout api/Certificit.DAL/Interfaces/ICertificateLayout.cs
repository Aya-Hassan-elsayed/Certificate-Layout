using Certificit.DAL.Entities;
using Certificit.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Interfaces
{
    public interface ICertificateLayout
    {
        public Task<IEnumerable<CertificateViewLayout33>> GetAll();
        public Task<CertificateViewLayout33?> GetByRequestNumber(string RequestNumber);
        public Task<IEnumerable<CertificateViewLayout33>> GetAllWithPram(ISpecification<CertificateViewLayout33> specification);
        public Task<int> GetTotalIteamCount(ISpecification<CertificateViewLayout33> specification);
    }
}
