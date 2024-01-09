using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class ArticleLocationMod
{

    public Guid articleId { get; set; }

    public Guid locationId { get; set; }

    public Guid emballageId { get; set; }

    public double seuil { get; set; }

    public double qteStock { get; set; }

    public int status { get; set; }

}
