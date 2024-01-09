using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class AchatList
    {
        public Guid id { get; set; }

        public DateTime dateAchat { get; set; }

        public string? numeroFacture { get; set; }

        public Guid locationId { get; set; }

        public string location { get; set; }

        public Guid fournisseurId { get; set; }

        public string fournisseur { get; set; }

        public double tauxAchat { get; set; }

        public double montantTotal { get; set; }

        public string? numeroAchat { get; set; }

        public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();
    }
}
