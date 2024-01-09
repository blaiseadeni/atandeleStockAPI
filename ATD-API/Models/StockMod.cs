using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class StockMod
{
    public Guid id { get; set; }
    public Guid articleId { get; set; }
    public Guid locationId { get; set; }
    public double quantite { get; set; }

}
