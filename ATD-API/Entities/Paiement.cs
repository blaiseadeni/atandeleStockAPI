using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Paiement
{
    public Guid id { get; set; }

    public string periode { get; set; }

    public Guid factureId { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime datePaiement { get; set; }

    public double montantPayer { get; set; }

    public virtual Facture Facture { get; set; } = null!;
}
