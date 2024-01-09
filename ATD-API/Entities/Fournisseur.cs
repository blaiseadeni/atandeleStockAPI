using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Fournisseur
{
    public Guid id { get; set; }

    public Guid utilisateurId { get; set; }

    public string nom { get; set; } = null!;

    public string ville { get; set; } = null!;

    public string adresse { get; set; } = null!;

    public string telephone { get; set; } = null!;

    public DateTime created { get; set; }


    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual ICollection<Livraison> Livraisons { get; set; } = new List<Livraison>();
}
