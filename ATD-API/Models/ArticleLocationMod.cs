using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ArticleLocationMod
{

    public Guid ArticleId { get; set; }

    public Guid LocationId { get; set; }

    public Guid EmballageId { get; set; }

    public double Seuil { get; set; }

    public double QteStock { get; set; }

    public int Status { get; set; }

}
