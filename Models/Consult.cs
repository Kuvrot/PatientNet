using System;
using System.Collections.Generic;

namespace PatientNet.Models;

public partial class Consult
{
    public int ConsultId { get; set; }

    public int PatientId { get; set; }

    public string? Date { get; set; }

    public string? Observations { get; set; }

    public string? Diagnostic { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
