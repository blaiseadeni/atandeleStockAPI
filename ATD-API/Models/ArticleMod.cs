using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ArticleMod
{

    public string? Code { get; set; } = "ART-" + new Random().Next();

    public string? Designation { get; set; }

    public Guid FamilleId { get; set; }

    public Guid EmballageGrosId { get; set; }

    public Guid EmballageDetailId { get; set; }

    public int StockMinimal { get; set; }

    public int QuantiteDetail { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

}
