using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class ArticleLocation
{
    public Guid id { get; set; }

    public Guid articleId { get; set; }

    public Guid locationId { get; set; }

    public Guid emballageId { get; set; }

    public double seuil { get; set; }

    public double qteStock { get; set; }

    public int status { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Emballage Emballage { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
