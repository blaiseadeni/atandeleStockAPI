using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class EmballageByArticle
{
    public Guid id { get; set; }

    public Guid articleId { get; set; }

    public string emballageGros { get; set; }

    public string emballageDetail { get; set; }

}
