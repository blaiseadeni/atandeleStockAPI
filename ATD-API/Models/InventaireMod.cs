using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class InventaireMod
{

    public string? DateInventaire { get; set; }

    public Guid LocationId { get; set; }

    public Guid ArticleId { get; set; }

    public string? Monnaie { get; set; }

    public string? EmballageGros { get; set; }

    public string? EmballageDetail { get; set; }

    public double PrixAchat { get; set; }

    public double PrixVente { get; set; }

    public double QuantitePhysiqueGros { get; set; }

    public double QuantitePhysiqueDetail { get; set; }

    public double QuantiteLogiqueGros { get; set; }

    public double QuatiteLogiqueDetail { get; set; }

    public double Ecart { get; set; }

}
