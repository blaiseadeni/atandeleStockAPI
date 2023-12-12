using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailAchat
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public string Article { get; set; }

    public Guid AchatId { get; set; }

    public string? Emballage { get; set; }

    public double Quantite { get; set; }

    public double PrixUnit { get; set; }

    public double PrixTotal { get; set; }

    //public virtual Achat Achat { get; set; } = null!;

    //public virtual Article Article { get; set; } = null!;
}
