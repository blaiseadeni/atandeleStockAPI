﻿using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class AchatList
    {
        public Guid Id { get; set; }

        public DateTime DateAchat { get; set; }

        public string? NumeroFacture { get; set; }

        public Guid MonnaieId { get; set; }
        public string Monnaie { get; set; }

        public Guid LocationId { get; set; }
        public string Location { get; set; }

        public Guid FournisseurId { get; set; }
        public string Fournisseur { get; set; }

        public double TauxAchat { get; set; }

        public double MontantTotal { get; set; }

        public string? NumeroAchat { get; set; }

        public virtual ICollection<DetailAchat> DetailAchats { get; set; } = new List<DetailAchat>();
    }
}
