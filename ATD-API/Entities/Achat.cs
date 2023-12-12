using System;
using System.Collections.Generic;

namespace ATD_API.Entities;

public partial class Achat
{
    public Guid Id { get; set; }

    public DateTime DateAchat { get; set; }

    public string? NumeroFacture { get; set; }

    public Guid MonnaieId { get; set; }

    public Guid LocationId { get; set; }

    public Guid FournisseurId { get; set; }

    public double TauxAchat { get; set; }

    public double MontantTotal { get; set; }

    public string? NumeroAchat { get; set; }

    public virtual ICollection<DetailAchat> DetailAchats { get; set; } = new List<DetailAchat>();

    public virtual Fournisseur Fournisseur { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Monnaie Monnaie { get; set; } = null!;
}
