﻿using System;
using System.Collections.Generic;

namespace Certificit.DAL.Entities;

public partial class UsageStatus
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public short? Type { get; set; }
}
