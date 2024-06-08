using Certificit.BLL.Interfaces;
using Certificit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Repositories
{
    public class UniteTypeRepository : IUniteType
    {
        public RSCContext RSCContext { get; }
        public UniteTypeRepository(RSCContext rSCContext)
        {
            RSCContext = rSCContext;
        }

        public IEnumerable<LkupUnittype> GetAll()
            => RSCContext.LkupUnittypes.ToList();

        public int GetByTypeName(string typeName)
        =>RSCContext.LkupUnittypes.Where(T =>T.Name == typeName).Select(T=> T.Id).FirstOrDefault();
    }
}
