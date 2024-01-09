using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ArticleMod
{

    public string? code { get; set; } = "ART-" + new Random().Next();

    public string? designation { get; set; }

    public Guid familleId { get; set; }

    public Guid utilisateurId { get; set; }

    public Guid emballageGrosId { get; set; }

    public Guid emballageDetailId { get; set; }

    public int stockMinimal { get; set; }

    public int quantiteDetail { get; set; }

    public DateTime created { get; set; } = DateTime.Now;

}
