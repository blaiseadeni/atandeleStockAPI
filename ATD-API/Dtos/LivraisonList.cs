using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class LivraisonList
    {
        public Guid Id { get; set; }
        public string? NumeroLivraison { get; set; }

        public string? NumeroCommande { get; set; }

        public DateTime DateLivraison { get; set; }

        public Guid FournisseurId { get; set; }
        public string Fournisseur { get; set; }

        public string? Observation { get; set; }

        public Guid LocationId { get; set; }
        public string Location { get; set; }

        public Guid MonnaieId { get; set; }
        public string Monnaie { get; set; }

        public virtual ICollection<DetailLivraison> DetailLivraisons { get; set; } = new List<DetailLivraison>();
    }
}
