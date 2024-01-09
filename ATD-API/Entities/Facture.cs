using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Facture
{
    public Guid id { get; set; }

    public string? periode { get; set; }

    public string? numeroFacture { get; set; }

    public Guid locationId { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime dateFacture { get; set; }

    public string? client { get; set; }


    public double taux { get; set; }

    public double remise { get; set; }

    public double totalHt { get; set; }

    public double montantPayer { get; set; }

    public double resteApayer { get; set; }

    public string? monnaie { get; set; }

    public string? montantLettre { get; set; }

    public string? paiement { get; set; }

    public string status { get; set; }

    public virtual ICollection<DetailFacture> detailFactures { get; set; } = new List<DetailFacture>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
