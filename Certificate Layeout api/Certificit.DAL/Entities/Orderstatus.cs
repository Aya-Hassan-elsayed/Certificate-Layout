using System;
using System.Collections.Generic;

namespace Certificit.DAL.Entities;

public partial class Orderstatus
{
    public int Orderstatusreference { get; set; }

    public string Orderstatusname { get; set; } = null!;
}
