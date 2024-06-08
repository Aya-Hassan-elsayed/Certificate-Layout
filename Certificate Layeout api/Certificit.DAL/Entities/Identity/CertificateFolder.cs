using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.DAL.Entities.Identity
{
    public class CertificateFolder
    {
        public  int Id {  get; set; }
        public string Foldername { get; set; }
        public string Folderpath { get; set; }
    }
}
