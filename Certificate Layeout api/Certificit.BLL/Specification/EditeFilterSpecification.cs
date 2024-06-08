using Certificit.DAL.Entities;
using Certificit.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Specification
{
    public class EditeFilterSpecification : BaseSpecification<CertificateViewLayoutEdit>
    {
        public EditeFilterSpecification(SpecificationPrams specificationPrams) : base
            (D =>
             (specificationPrams.UniteType == null || D.Unittype == specificationPrams.UniteType) &&
            (specificationPrams.RequestNumber == null || D.IdShippingorder == int.Parse(specificationPrams.RequestNumber)) &&
             (specificationPrams.Name == null || D.Name.Contains(specificationPrams.Name.Trim()))
            )
        {
            ApplaySpecificatiion(specificationPrams.PageSize, specificationPrams.PageSize * (specificationPrams.PageIndex - 1));
        }
    }
}
