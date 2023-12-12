using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Paiement
{
    public Guid Id { get; set; }

    public Guid FactureId { get; set; }

    public DateTime DatePaiement { get; set; }

    public double MontantPayer { get; set; }

    public virtual Facture Facture { get; set; } = null!;
}
