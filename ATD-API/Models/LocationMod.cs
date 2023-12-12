using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATD_API.Entities;

public partial class LocationMod
{

    public string? Designation { get; set; }

    public DateTime DateCreation { get; set; }

    public Guid SocieteId { get; set; }

    public bool Flag { get; set; }

    public string? Addresse { get; set; }

    public string? NumeroAchat { get; set; }

    public string? NumeroCommande { get; set; }

    public string? NumeroFacture { get; set; }

    public string? NumeroLivraison { get; set; }

}
