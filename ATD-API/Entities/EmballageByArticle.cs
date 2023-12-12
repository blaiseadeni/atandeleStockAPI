using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class EmballageByArticle
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public string EmballageGros { get; set; }

    public string EmballageDetail { get; set; }

}
