using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class CommandeMod
{

    public Guid utilisateurId { get; set; }

    public string periode { get; set; } = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

    public string? numeroCommande { get; set; }

    public DateTime dateCommande { get; set; }

    public DateTime dateLivraison { get; set; }

    //public string? echeance { get; set; }

    public Guid fournisseurId { get; set; }

    //public string? observation { get; set; }

    //public string? concerne { get; set; }

    public double totalCommande { get; set; }

    public double tauxDeChange { get; set; }

    public bool status { get; set; } = false;

    public virtual ICollection<DetailCommande> detailCommandes { get; set; } = new List<DetailCommande>();

}
