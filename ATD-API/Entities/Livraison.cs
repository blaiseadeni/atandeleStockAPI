using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Livraison
{
    public Guid Id { get; set; }

    public string? NumeroLivraison { get; set; }

    public string? NumeroCommande { get; set; }

    public DateTime DateLivraison { get; set; }

    public Guid FournisseurId { get; set; }

    public string? Observation { get; set; }

    public Guid LocationId { get; set; }

    public Guid MonnaieId { get; set; }

    public virtual ICollection<DetailLivraison> DetailLivraisons { get; set; } = new List<DetailLivraison>();

    public virtual Fournisseur Fournisseur { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Monnaie Monnaie { get; set; } = null!;
}
