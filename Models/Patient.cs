using System;
using System.Collections.Generic;

namespace PatientNet.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Birthdate { get; set; }

    public string? Sex { get; set; }

    public string? Allergies { get; set; }

    public string? Observations { get; set; }

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();
}
