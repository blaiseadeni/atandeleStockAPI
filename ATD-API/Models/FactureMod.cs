using ATD_API.Factories;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace ATD_API.Entities;

public partial class FactureMod
{

    public string? NumeroFacture { get; set; }

    public Guid LocationId { get; set; }

    public DateTime DateFacture { get; set; } = DateTime.Now;

    public string? Client { get; set; }

    public double Taux { get; set; }

    public double Remise { get; set; }

    public double TotalHt { get; set; }

    public double MontantPayer { get; set; }

    public double ResteApayer { get; set; }

    public string? Monnaie { get; set; }

    public string? MontantLettre { get; set; } = "NULL";

    public string? Paiement { get; set; }

    public string Status { get; set; }

    public virtual ICollection<DetailFacture> DetailFactures { get; set; } = new List<DetailFacture>();

}
