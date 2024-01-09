using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Location
{
    public Guid id { get; set; }

    public string? designation { get; set; }

    public DateTime dateCreation { get; set; }

    public Guid societeId { get; set; }

    public string? dateCloture { get; set; }

    public bool flag { get; set; }

    public string? addresse { get; set; }

    public string? numeroAchat { get; set; }

    public string? numeroCommande { get; set; }

    public string? numeroFacture { get; set; }

    public string? numeroLivraison { get; set; }


    public virtual ICollection<ArticleLocation> ArticleLocations { get; set; } = new List<ArticleLocation>();

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    public virtual ICollection<Inventaire> Inventaires { get; set; } = new List<Inventaire>();

    public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();

    public virtual ICollection<PrixArticleLocation> PrixArticleLocations { get; set; } = new List<PrixArticleLocation>();

    public virtual ParametreSociete Societe { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
