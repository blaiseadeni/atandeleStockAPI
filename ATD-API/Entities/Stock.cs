using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Stock
{

    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid LocationId { get; set; }
    public double Quantite { get; set; }

    // public virtual Article Article { get; set; } = null!;

    //public virtual Location Location { get; set; } = null!;
}
