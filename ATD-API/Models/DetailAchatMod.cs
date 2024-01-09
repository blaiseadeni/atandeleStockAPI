using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailAchatMod
{

    public Guid articleId { get; set; }

    public string article { get; set; }

    public Guid achatId { get; set; }

    public string? emballage { get; set; }

    public double quantite { get; set; }

    public double prixUnit { get; set; }

    public double prixTotal { get; set; }

}
