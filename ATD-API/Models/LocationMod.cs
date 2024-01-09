using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATD_API.Entities;

public partial class LocationMod
{

    public string? designation { get; set; }

    public DateTime dateCreation { get; set; }

    public Guid societeId { get; set; }

    public bool flag { get; set; }

    public string? addresse { get; set; }

    public string? numeroAchat { get; set; }

    public string? numeroCommande { get; set; }

    public string? numeroFacture { get; set; }

    public string? numeroLivraison { get; set; }

}
