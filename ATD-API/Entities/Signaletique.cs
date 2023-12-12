using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Signaletique
{
    public Guid Id { get; set; }

    public string Categorie { get; set; } = null!;

    public string? Nom { get; set; }

    public string? Telephone { get; set; }

    public string? Addresse { get; set; }

    public string? RaisonSociale { get; set; }

    public string? Email { get; set; }
}
