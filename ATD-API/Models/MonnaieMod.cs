using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class MonnaieMod
{

    public string? Devise { get; set; }

    public string? Libelle { get; set; }

    public bool estLocal { get; set; } = false;

    public DateTime Created { get; set; } = DateTime.Now;

}
