using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class PrixAchatArticleMod
{

    public string? DateAchat { get; set; }

    public Guid ArticleId { get; set; }

    public Guid MonnaieId { get; set; }

    public double PrixAchatGros { get; set; }

    public double PrixAchatDetail { get; set; }

}
