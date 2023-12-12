using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class CommandeList
    {
        public Guid Id { get; set; }

        public string? NumeroCommande { get; set; }

        public DateTime DateCommande { get; set; }

        public DateTime DateLivraison { get; set; }

        public string? Echeance { get; set; }

        public Guid FournisseurId { get; set; }
        public string Fournisseur { get; set; }


        public string? Observation { get; set; }

        public string? Concerne { get; set; }

        public double TotalCommande { get; set; }

        public Guid MonnaieId { get; set; }


        public string Monnaie { get; set; }

        public double TauxDeChange { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<DetailCommande> DetailCommandes { get; set; } = new List<DetailCommande>();
    }
}
