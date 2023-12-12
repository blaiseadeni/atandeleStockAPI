using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Emballage
{
    public Guid Id { get; set; }

    public string? Libelle { get; set; }

    public DateTime Created { get; set; }

    // public virtual ICollection<Article> ArticleEmballageDetails { get; set; } = new List<Article>();

    // public virtual ICollection<Article> ArticleEmballageGros { get; set; } = new List<Article>();

    public virtual ICollection<ArticleLocation> ArticleLocations { get; set; } = new List<ArticleLocation>();
}
