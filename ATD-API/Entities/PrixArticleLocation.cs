using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixArticleLocation
{
    public Guid id { get; set; }

    public double prixVenteDetail { get; set; }

    public double prixVenteGros { get; set; }

    public Guid locationId { get; set; }

    public Guid articleId { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime? created { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
