using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixArticleLocation
{
    public Guid Id { get; set; }

    public double PrixVenteDetail { get; set; }

    public double PrixVenteGros { get; set; }

    public string? Monnaie { get; set; }

    public Guid LocationId { get; set; }

    public Guid ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
