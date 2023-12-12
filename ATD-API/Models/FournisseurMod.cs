using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class FournisseurMod
{

    public string Nom { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public DateTime Created { get; set; } = DateTime.Now;

}
