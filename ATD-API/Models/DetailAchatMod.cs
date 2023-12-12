using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailAchatMod
{

    public Guid ArticleId { get; set; }
    public string Article { get; set; }

    public Guid AchatId { get; set; }

    public string? Emballage { get; set; }

    public double Quantite { get; set; }

    public double PrixUnit { get; set; }

    public double PrixTotal { get; set; }

}
