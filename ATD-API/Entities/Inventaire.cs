using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Inventaire
{
    public Guid id { get; set; }

    public DateTime date { get; set; }

    public DateTime date1 { get; set; }

    public DateTime date2 { get; set; }

    public Guid articleId { get; set; }

    public Guid locationId { get; set; }

    public Guid utilisateurId { get; set; }

    public double quantitePhysique { get; set; }

    public double quantiteLogique { get; set; }

    public double ecart { get; set; }

    //public virtual Article Article { get; set; } = null!;

    //public virtual Location Location { get; set; } = null!;
}
