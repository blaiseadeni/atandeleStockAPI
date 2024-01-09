using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixArticleLocationMod
{

    public double prixVenteDetail { get; set; }

    public double prixVenteGros { get; set; }

    public Guid locationId { get; set; }

    public Guid articleId { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime created { get; set; } = DateTime.Now;


}
