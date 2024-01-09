using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Achat
{
    public Guid id { get; set; }

    public string periode { get; set; }

    public Guid utilisateurId { get; set; }

    public DateTime dateAchat { get; set; }

    public string? numeroFacture { get; set; }

    public Guid locationId { get; set; }

    public Guid fournisseurId { get; set; }

    public double tauxAchat { get; set; }

    public double montantTotal { get; set; }

    public string? numeroAchat { get; set; }

    public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();

    public virtual Fournisseur Fournisseur { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

}
