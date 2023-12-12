using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class EmballageMod
{

    public string? Libelle { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;
}
