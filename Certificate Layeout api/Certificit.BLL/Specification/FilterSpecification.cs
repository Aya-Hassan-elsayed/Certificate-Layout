using Certificit.DAL.Entities;
using Certificit.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.BLL.Specification
{
    public class FilterSpecification : BaseSpecification<CertificateViewLayout33>
    {
        public FilterSpecification(SpecificationPrams specificationPrams) : base(
            D =>
                
                //(specificationPrams.SurveyReview != 0 && D.SurveyReview == specificationPrams.SurveyReview) &&
                (string.IsNullOrEmpty(specificationPrams.UniteType) || D.Unittype == specificationPrams.UniteType) &&
                (string.IsNullOrEmpty(specificationPrams.Name) || D.Name.Contains(specificationPrams.Name.Trim())) &&
                (string.IsNullOrEmpty(specificationPrams.RequestNumber)|| D.Requestnumber.Contains(specificationPrams.RequestNumber.Trim())))
        {
            ApplaySpecificatiion(specificationPrams.PageSize, specificationPrams.PageSize * (specificationPrams.PageIndex - 1));        
        }
    }
}
