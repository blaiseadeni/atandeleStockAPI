using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class Article
{
    public Guid id { get; set; }

    public Guid utilisateurId { get; set; }

    public string? code { get; set; }

    public string? designation { get; set; }

    public Guid familleId { get; set; }

    public Guid emballageGrosId { get; set; }

    public Guid emballageDetailId { get; set; }
    public int stockMinimal { get; set; }

    public int quantiteDetail { get; set; }

    public DateTime created { get; set; }

    [NotMapped]
    public virtual ICollection<ArticleLocation> articleLocations { get; set; } = new List<ArticleLocation>();

    public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();
    [NotMapped]
    public virtual ICollection<DetailCommande> detailCommandes { get; set; } = new List<DetailCommande>();
    [NotMapped]
    public virtual ICollection<DetailFacture> detailFactures { get; set; } = new List<DetailFacture>();
    //[NotMapped]
    //  public virtual Emballage EmballageDetail { get; set; } = null!;
    //[NotMapped]
    // public virtual Emballage EmballageGros { get; set; } = null!;

    public virtual Famille Famille { get; set; } = null!;

    public virtual ICollection<Inventaire> Inventaires { get; set; } = new List<Inventaire>();

    public virtual ICollection<PrixAchatArticle> PrixAchatArticles { get; set; } = new List<PrixAchatArticle>();

    public virtual ICollection<PrixArticleLocation> PrixArticleLocations { get; set; } = new List<PrixArticleLocation>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
