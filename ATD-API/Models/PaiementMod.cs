using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PaiementMod
{

    public Guid FactureId { get; set; }

    public DateTime DatePaiement { get; set; } = DateTime.Now;

    public double MontantPayer { get; set; }

}
