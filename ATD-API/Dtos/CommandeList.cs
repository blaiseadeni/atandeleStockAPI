using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class CommandeList
    {
        public Guid id { get; set; }

        public string? numeroCommande { get; set; }

        public DateTime dateCommande { get; set; }

        public DateTime dateLivraison { get; set; }

        public string? echeance { get; set; }

        public Guid fournisseurId { get; set; }

        public string fournisseur { get; set; }


        public string? observation { get; set; }

        public string? concerne { get; set; }

        public double totalCommande { get; set; }

        public Guid monnaieId { get; set; }


        public string monnaie { get; set; }

        public double tauxDeChange { get; set; }

        public bool status { get; set; }

        public virtual ICollection<DetailCommande> detailCommandes { get; set; } = new List<DetailCommande>();
    }
}
