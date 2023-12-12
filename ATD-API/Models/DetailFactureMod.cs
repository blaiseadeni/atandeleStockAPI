using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailFactureMod
{

    public Guid ArticleId { get; set; }

    public Guid FactureId { get; set; }

    public string? Emballage { get; set; }

    public double Quantite { get; set; }

    public double PrixUnit { get; set; }

    public double PrixTotal { get; set; }

}
