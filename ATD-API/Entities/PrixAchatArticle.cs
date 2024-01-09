using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixAchatArticle
{
    public Guid id { get; set; }

    public string? dateAchat { get; set; }

    public Guid articleId { get; set; }

    public Guid monnaieId { get; set; }

    public double prixAchatGros { get; set; }

    public double prixAchatDetail { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Monnaie Monnaie { get; set; } = null!;
}
