using Certificit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Interfaces
{
    public interface IUniteType
    {
        public IEnumerable<LkupUnittype> GetAll();
        public int GetByTypeName(string typeName);
    }
}
