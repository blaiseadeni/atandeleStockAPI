﻿using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class DetailCommandeMod
{

    public Guid articleId { get; set; }

    public string article { get; set; }

    public Guid commandeId { get; set; }

    public string? emballage { get; set; }

    public double quantite { get; set; }

    public double quantiteLivree { get; set; }

    public double resteQuantite { get; set; }

    public double prixUnit { get; set; }

    public double prixTotal { get; set; }

}
