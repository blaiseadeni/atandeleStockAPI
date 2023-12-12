using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class FamilleMod
{
    public string? Libelle { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

}
