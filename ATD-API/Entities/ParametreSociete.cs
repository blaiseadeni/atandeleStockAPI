using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ParametreSociete
{
    public Guid Id { get; set; }

    public string? Denomination { get; set; }

    public string? Telephone { get; set; }

    public string? Addresse { get; set; }

    public string? Ville { get; set; }

    public string? IdNat { get; set; }

    public string? Rccm { get; set; }

    public double Tva { get; set; }

    public string? Monnaie { get; set; }
    public int Attachement { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
