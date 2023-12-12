using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixAchatArticle
{
    public Guid Id { get; set; }

    public string? DateAchat { get; set; }

    public Guid ArticleId { get; set; }

    public Guid MonnaieId { get; set; }

    public double PrixAchatGros { get; set; }

    public double PrixAchatDetail { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Monnaie Monnaie { get; set; } = null!;
}
