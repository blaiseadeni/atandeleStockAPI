using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class HistoriquePrixVente
{
    public Guid id { get; set; }
    public Guid articleId { get; set; }
    public Guid utilisateurId { get; set; }
    public Guid locationId { get; set; }
    public DateTime dateModification { get; set; }
    public double ancienPrixDeVenteGros { get; set; }
    public double ancienPrixDeVenteDetail { get; set; }
    public double nouveauPrixDeVenteGros { get; set; }
    public double nouveauPrixDeVenteDetail { get; set; }
}
