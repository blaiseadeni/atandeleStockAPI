using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ParametreSocieteMod
{

    public Guid utilisateurId { get; set; }

    public DateTime created { get; set; } = DateTime.Now;

    public string? denomination { get; set; }

    public string? telephone { get; set; }

    public string? addresse { get; set; }

    public string? ville { get; set; }

    public string? idNat { get; set; }

    public string? rccm { get; set; }

    public double tva { get; set; }

    public string? monnaie { get; set; }

    public int attachement { get; set; }

}
