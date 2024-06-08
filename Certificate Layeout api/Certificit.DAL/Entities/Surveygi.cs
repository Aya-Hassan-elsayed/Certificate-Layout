using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Certificit.DAL.Entities;

public partial class Surveygi
{
    public long Ids { get; set; }

    public string Seragid { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string? XValidation { get; set; }

    public string? YValidation { get; set; }

    public MultiPolygon Geom { get; set; } = null!;

    public int? Districtid { get; set; }
}
