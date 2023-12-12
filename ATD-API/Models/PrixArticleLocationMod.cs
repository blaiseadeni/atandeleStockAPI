using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixArticleLocationMod
{

    public double PrixVenteDetail { get; set; }

    public double PrixVenteGros { get; set; }

    public string? Monnaie { get; set; }

    public Guid LocationId { get; set; }

    public Guid ArticleId { get; set; }

   
}
