using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATD_API.Entities;

public partial class Article
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Designation { get; set; }

    public Guid FamilleId { get; set; }

    public Guid EmballageGrosId { get; set; }

    public Guid EmballageDetailId { get; set; }
    public int StockMinimal { get; set; }

    public int QuantiteDetail { get; set; }

    public DateTime Created { get; set; }

    [NotMapped]
    public virtual ICollection<ArticleLocation> ArticleLocations { get; set; } = new List<ArticleLocation>();

    public virtual ICollection<DetailAchat> DetailAchats { get; set; } = new List<DetailAchat>();
    [NotMapped]
    public virtual ICollection<DetailCommande> DetailCommandes { get; set; } = new List<DetailCommande>();
    [NotMapped]
    public virtual ICollection<DetailFacture> DetailFactures { get; set; } = new List<DetailFacture>();
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
