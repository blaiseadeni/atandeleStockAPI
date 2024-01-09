using ATD_API.Factories;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace ATD_API.Entities;

public partial class FactureMod
{

    public string? numeroFacture { get; set; }

    public string? periode { get; set; }

    public Guid locationId { get; set; }

    public DateTime dateFacture { get; set; } = DateTime.Now;

    public string? client { get; set; }

    public double taux { get; set; }

    public double remise { get; set; }

    public double totalHt { get; set; }

    public double montantPayer { get; set; }

    public double resteApayer { get; set; }

    public string? monnaie { get; set; }

    public string? montantLettre { get; set; } = "NULL";

    public string? paiement { get; set; }

    public string status { get; set; }

    public Guid utilisateurId { get; set; }

    public virtual ICollection<DetailFacture> detailFactures { get; set; } = new List<DetailFacture>();

}
