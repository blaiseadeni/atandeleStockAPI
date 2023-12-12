using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Monnaie
{
    public Guid Id { get; set; }

    public string? Devise { get; set; }

    public string? Libelle { get; set; }

    public bool estLocal { get; set; }

    public DateTime Created { get; set; }


    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();

    public virtual ICollection<PrixAchatArticle> PrixAchatArticles { get; set; } = new List<PrixAchatArticle>();

    public virtual ICollection<Portefeuille> Portefeuilles { get; set; } = new List<Portefeuille>();
}
