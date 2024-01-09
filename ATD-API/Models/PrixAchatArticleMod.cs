using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixAchatArticleMod
{

    public string? dateAchat { get; set; }

    public Guid articleId { get; set; }

    public Guid monnaieId { get; set; }

    public double prixAchatGros { get; set; }

    public double prixAchatDetail { get; set; }

}
