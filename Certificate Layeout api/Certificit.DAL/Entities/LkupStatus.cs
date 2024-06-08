using System;
using System.Collections.Generic;

namespace Certificit.DAL.Entities;

public partial class LkupStatus
{
    public long Id { get; set; }

    public int? Code { get; set; }

    public string? Status { get; set; }
}
