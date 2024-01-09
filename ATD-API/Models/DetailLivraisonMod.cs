using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailLivraisonMod
{

    public Guid articleId { get; set; }

    public Guid livraisonId { get; set; }

    public string? emballage { get; set; }

    public double quantite { get; set; }

    public double prixUnit { get; set; }

    public double prixTotal { get; set; }

}
