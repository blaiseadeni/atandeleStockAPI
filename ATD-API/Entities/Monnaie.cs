using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Monnaie
{
    public Guid id { get; set; }


    public Guid utilisateurId { get; set; }

    public string? devise { get; set; }

    public string? libelle { get; set; }

    public bool estLocal { get; set; }

    public DateTime created { get; set; }


    //public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    //public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();

    public virtual ICollection<PrixAchatArticle> PrixAchatArticles { get; set; } = new List<PrixAchatArticle>();

    //public virtual ICollection<Portefeuille> Portefeuilles { get; set; } = new List<Portefeuille>();
}
