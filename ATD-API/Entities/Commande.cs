using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Commande
{
    public Guid id { get; set; }

    public string periode { get; set; }

    public Guid utilisateurId { get; set; }

    public string? numeroCommande { get; set; }

    public DateTime dateCommande { get; set; }

    public DateTime dateLivraison { get; set; }

    //public string? echeance { get; set; }

    public Guid fournisseurId { get; set; }

    //public string? observation { get; set; }

    //public string? concerne { get; set; }

    public double totalCommande { get; set; }

    public double tauxDeChange { get; set; }

    public bool status { get; set; }

    public virtual ICollection<DetailCommande> detailCommandes { get; set; } = new List<DetailCommande>();

    public virtual Fournisseur? Fournisseur { get; set; }

}
