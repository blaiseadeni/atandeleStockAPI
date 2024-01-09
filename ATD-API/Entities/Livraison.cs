using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Livraison
{
    public Guid id { get; set; }

    public string? periode { get; set; }

    public Guid utilisateurId { get; set; }

    public string? numeroLivraison { get; set; }

    public string? numeroCommande { get; set; }

    public DateTime dateLivraison { get; set; }

    public Guid fournisseurId { get; set; }

    public string? observation { get; set; }

    public Guid locationId { get; set; }

    public double totalLivraison { get; set; }

    public virtual ICollection<DetailLivraison> detailLivraisons { get; set; } = new List<DetailLivraison>();

    public virtual Fournisseur Fournisseur { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

}
