using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PaiementMod
{

    public string periode { get; set; } = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

    public Guid factureId { get; set; }

    public DateTime datePaiement { get; set; } = DateTime.Now;

    public double montantPayer { get; set; }

    public Guid utilisateurId { get; set; }

}
