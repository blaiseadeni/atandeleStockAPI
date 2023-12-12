using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Fournisseur
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public DateTime Created { get; set; }


    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();
}
