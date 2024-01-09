using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Signaletique
{
    public Guid id { get; set; }

    public string categorie { get; set; } = null!;

    public string? nom { get; set; }

    public string? telephone { get; set; }

    public string? addresse { get; set; }

    //public string? raisonSociale { get; set; }

    //public string? email { get; set; }

    public DateTime created { get; set; }

    public Guid utilisateurId { get; set; }
}
