using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class CoursDeChangeMod
{

    public DateTime dateEnCours { get; set; }

    public double tauxAchat { get; set; }

    public double tauxVente { get; set; }

    public string? monnaie { get; set; }

    public Guid utilisateurId { get; set; }

}
