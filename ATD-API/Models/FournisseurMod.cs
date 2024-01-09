using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class FournisseurMod
{

    public string nom { get; set; } = null!;

    public Guid utilisateurId { get; set; }

    public string ville { get; set; } = null!;

    public string adresse { get; set; } = null!;

    public string telephone { get; set; } = null!;

    public DateTime created { get; set; } = DateTime.Now;

}
