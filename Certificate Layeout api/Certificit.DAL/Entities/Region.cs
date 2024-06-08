﻿using System;
using System.Collections.Generic;

namespace Certificit.DAL.Entities;

public partial class Region
{
    public int Id { get; set; }

    public string? Englishname { get; set; }

    public string? Arabicname { get; set; }

    public int? Governorateid { get; set; }

    public string? Createdby { get; set; }

    public string? Updatedby { get; set; }

    public string? Addeddate { get; set; }

    public string? Modifieddate { get; set; }

    public int? Surveyteamid { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public int? Crewtransfercost { get; set; }
}
