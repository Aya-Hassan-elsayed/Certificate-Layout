using System;
using System.Collections.Generic;

namespace Certificit.DAL.test;

public partial class CertificateCoverView
{
    public string? Requestnumber { get; set; }

    public int? OldUnittype { get; set; }

    public int? OldSubunittype { get; set; }

    public double? OldArea { get; set; }

    public string? OldBuildingarea { get; set; }

    public string? OldLandarea { get; set; }

    public int? OldAreatype { get; set; }

    public double? OldSubunittypearea { get; set; }

    public decimal? NewArealand { get; set; }

    public decimal? NewAreabuilding { get; set; }

    public float? NewAreaApartment { get; set; }

    public int? NewUnittype { get; set; }

    public short? NewUsage { get; set; }

    public double? OldPrice { get; set; }

    public string? Arabicfullname { get; set; }

    public string? Address { get; set; }

    public string? Telephonenumber { get; set; }

    public string? Telephonenumber2 { get; set; }

    public string? SsecName { get; set; }

    public string? SecName { get; set; }

    public string? Gov { get; set; }

    public string? Comment { get; set; }
}
