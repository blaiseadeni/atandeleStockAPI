using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Stock
{

    public Guid id { get; set; }
    public Guid articleId { get; set; }
    public Guid locationId { get; set; }
    public double quantite { get; set; }

    // public virtual Article Article { get; set; } = null!;

    //public virtual Location Location { get; set; } = null!;
}
