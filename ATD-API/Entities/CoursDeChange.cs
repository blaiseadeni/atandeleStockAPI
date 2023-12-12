using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class CoursDeChange
{
    public Guid Id { get; set; }

    public DateTime DateEnCours { get; set; }

    public double TauxAchat { get; set; }

    public double TauxVente { get; set; }

    public string? Monnaie { get; set; }
}
