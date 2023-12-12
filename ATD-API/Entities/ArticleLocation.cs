using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class ArticleLocation
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public Guid LocationId { get; set; }

    public Guid EmballageId { get; set; }

    public double Seuil { get; set; }

    public double QteStock { get; set; }

    public int Status { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Emballage Emballage { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
