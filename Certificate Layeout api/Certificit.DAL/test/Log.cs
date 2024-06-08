using System;
using System.Collections.Generic;

namespace Certificit.DAL.test;

public partial class Log
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Note { get; set; }

    public string? Email { get; set; }

    public TimeOnly? Date { get; set; }
}
