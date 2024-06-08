using System;
using System.Collections.Generic;

namespace Certificit.DAL.Entities;

public partial class Ssec
{
    public int Id { get; set; }

    public string? SecCode { get; set; }

    public string? SsecCode { get; set; }

    public string? SsecNameEn { get; set; }

    public string? SsecNameAr { get; set; }

    public int? Regionid { get; set; }

    public int Districtid { get; set; }
}
