using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailFacture
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public string Article { get; set; }

    public Guid FactureId { get; set; }

    public string? Emballage { get; set; }

    public double Quantite { get; set; }

    public double PrixUnit { get; set; }

    public double PrixTotal { get; set; }

    //  public virtual Article Article { get; set; } = null!;

    // public virtual Facture Facture { get; set; } = null!;
}
