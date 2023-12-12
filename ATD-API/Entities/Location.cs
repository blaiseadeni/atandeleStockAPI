using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Location
{
    public Guid Id { get; set; }

    public string? Designation { get; set; }

    public DateTime DateCreation { get; set; }

    public Guid SocieteId { get; set; }

    public string? DateCloture { get; set; }

    public bool Flag { get; set; }

    public string? Addresse { get; set; }

    public string? NumeroAchat { get; set; }

    public string? NumeroCommande { get; set; }

    public string? NumeroFacture { get; set; }

    public string? NumeroLivraison { get; set; }


    public virtual ICollection<ArticleLocation> ArticleLocations { get; set; } = new List<ArticleLocation>();

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    public virtual ICollection<Inventaire> Inventaires { get; set; } = new List<Inventaire>();

    public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();

    public virtual ICollection<PrixArticleLocation> PrixArticleLocations { get; set; } = new List<PrixArticleLocation>();

    public virtual ParametreSociete Societe { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
