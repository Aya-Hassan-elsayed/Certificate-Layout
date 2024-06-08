﻿using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Certificit.DAL.Entities;

public partial class CertificateViewLayoutEdit
{
    public int? Id { get; set; }

    public string? Requestnumber { get; set; }

    public int? IdShippingorder { get; set; }

    public string? ShipRequestnumber { get; set; }

    public int? ShipStatus { get; set; }

    public long? ShipPrintStatus { get; set; }

    public DateOnly? ShipPrintDate { get; set; }

    public long? ShipRecert { get; set; }

    public DateOnly? ShipTofedex { get; set; }

    public int? CompanyId { get; set; }

    public int? SurveyTeamId { get; set; }

    public string? Gov { get; set; }

    public string? Sec { get; set; }

    public string? Ssec { get; set; }

    public string? Streetname { get; set; }

    public string? PropertyN { get; set; }

    public DateOnly? Addeddate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Unittype { get; set; }

    public string? FloorNumb { get; set; }

    public string? FloorNT { get; set; }

    public string? ApartNum { get; set; }

    public string? Surveynum { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? NorthB { get; set; }

    public string? SouthB { get; set; }

    public string? EastB { get; set; }

    public string? WestB { get; set; }

    public float? NorthL { get; set; }

    public float? SouthL { get; set; }

    public float? EastL { get; set; }

    public float? WestL { get; set; }

    public decimal? AreaLand { get; set; }

    public decimal? AreaBuild { get; set; }

    public float? Garden { get; set; }

    public float? Manwr { get; set; }

    public float? Sealmm { get; set; }

    public float? Sealm { get; set; }

    public string? Ket3a { get; set; }

    public string? Hod { get; set; }

    public string? Usage { get; set; }

    public string? Descrip { get; set; }

    public float? NorthL1 { get; set; }

    public float? SouthL1 { get; set; }

    public float? EastL1 { get; set; }

    public float? WestL1 { get; set; }

    public float? AreaAp1 { get; set; }

    public float? NorthL2 { get; set; }

    public float? SouthL2 { get; set; }

    public float? EastL2 { get; set; }

    public float? WestL2 { get; set; }

    public float? AreaAp2 { get; set; }

    public float? NorthL3 { get; set; }

    public float? SouthL3 { get; set; }

    public float? EastL3 { get; set; }

    public float? WestL3 { get; set; }

    public float? AreaAp3 { get; set; }

    public float? NorthL4 { get; set; }

    public float? SouthL4 { get; set; }

    public float? EastL4 { get; set; }

    public float? WestL4 { get; set; }

    public float? AreaAp4 { get; set; }

    public float? NorthL5 { get; set; }

    public float? SouthL5 { get; set; }

    public float? EastL5 { get; set; }

    public float? WestL5 { get; set; }

    public float? AreaAp5 { get; set; }

    public float? NorthL6 { get; set; }

    public float? SouthL6 { get; set; }

    public float? EastL6 { get; set; }

    public float? WestL6 { get; set; }

    public float? AreaAp6 { get; set; }

    public string? X { get; set; }

    public string? Y { get; set; }

    public float? Totalarea { get; set; }

    public float? Totalaparts { get; set; }

    public MultiPolygon? Geom { get; set; }

    public string? Serag { get; set; }

    public long? ShaqaaSeragCount { get; set; }

    public long? SeragidCount { get; set; }

    public string? Seragid { get; set; }

    public string? SeragShaqaa { get; set; }

    public string? Overlap { get; set; }

    public string? Ncpslu { get; set; }

    public DateTime? Printdate { get; set; }

    public string? MilOverlap { get; set; }

    public string? Receiptimagepath { get; set; }

    public float? NorthLg { get; set; }

    public float? SouthLg { get; set; }

    public float? EastLg { get; set; }

    public float? WestLg { get; set; }

    public float? AreaG { get; set; }

    public string? Print { get; set; }

    public short? Tawheed { get; set; }

    public string? SsecNow { get; set; }

    public string? SecNow { get; set; }

    public string? GovNo { get; set; }

    public char? Letter { get; set; }

    public long? Numberofcopies { get; set; }
}
