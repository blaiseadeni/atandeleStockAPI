using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class HistoriquePrixVente
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public string? DateModification { get; set; }

    public double AncienPrixDeVenteGros { get; set; }

    public double AncienPrixDeVenteDetail { get; set; }

    public double NouveauPrixDeVenteGros { get; set; }

    public double NouveauPrixDeVenteDetail { get; set; }

    public string? Monnaie { get; set; }
}
