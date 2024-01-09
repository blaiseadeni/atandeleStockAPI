using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ParametreSociete
{
    public Guid id { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime created { get; set; }

    public string? denomination { get; set; }

    public string? telephone { get; set; }

    public string? addresse { get; set; }

    public string? ville { get; set; }

    public string? idNat { get; set; }

    public string? rccm { get; set; }

    public double tva { get; set; }

    public string? monnaie { get; set; }

    public int attachement { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
