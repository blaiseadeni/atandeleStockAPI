using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class LivraisonList
    {
        public Guid id { get; set; }
        public string? numeroLivraison { get; set; }

        public string? numeroCommande { get; set; }

        public DateTime dateLivraison { get; set; }

        public Guid fournisseurId { get; set; }
        public string fournisseur { get; set; }

        public string? observation { get; set; }

        public Guid locationId { get; set; }

        public string location { get; set; }

        public double totalLivraison { get; set; }


        public virtual ICollection<DetailLivraison> detailLivraisons { get; set; } = new List<DetailLivraison>();
    }
}
