using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailCommandeMod
{

    public Guid ArticleId { get; set; }

    public string Article { get; set; }

    public Guid CommandeId { get; set; }

    public string? Emballage { get; set; }

    public double Quantite { get; set; }

    public double QuantiteLivree { get; set; }

    public double ResteQuantite { get; set; }

    public double PrixUnit { get; set; }

    public double PrixTotal { get; set; }

}
