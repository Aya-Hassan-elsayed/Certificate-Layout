using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Certificit.DAL.Entities;

public partial class SsecGeom
{
    public long Id { get; set; }

    public MultiPolygon? Geom { get; set; }

    public string? SecCode { get; set; }

    public string? SsecCode { get; set; }

    public string? SsecName { get; set; }

    public int? Districtid { get; set; }
}
