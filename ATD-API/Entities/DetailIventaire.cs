using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailIventaire
{
    public Guid id { get; set; }

    public Guid inventaireId { get; set; }

    public Guid articleId { get; set; }

    public string? emballage { get; set; }

    public double quantitePhysique { get; set; }

    public double quantiteLogique { get; set; }

    public double ecart { get; set; }
}
