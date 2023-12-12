using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailIventaire
{
    public Guid Id { get; set; }

    public Guid InventaireId { get; set; }

    public Guid ArticleId { get; set; }

    public string? Emballage { get; set; }

    public double QuantitePhysique { get; set; }

    public double QuantiteLogique { get; set; }

    public double Ecart { get; set; }
}
