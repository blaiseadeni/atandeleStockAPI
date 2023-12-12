using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Facture
{
    public Guid Id { get; set; }

    public string? NumeroFacture { get; set; }

    public Guid LocationId { get; set; }

    public DateTime DateFacture { get; set; }

    public string? Client { get; set; }

    public double Taux { get; set; }

    public double Remise { get; set; }

    public double TotalHt { get; set; }

    public double MontantPayer { get; set; }

    public double ResteApayer { get; set; }

    public string? Monnaie { get; set; }

    public string? MontantLettre { get; set; }

    public string? Paiement { get; set; }

    public string Status { get; set; }

    public virtual ICollection<DetailFacture> DetailFactures { get; set; } = new List<DetailFacture>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
