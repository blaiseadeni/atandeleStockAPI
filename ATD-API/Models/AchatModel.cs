using ATD_API.Entities;

namespace ATD_API.Models
{
    public class AchatModel
    {

        public string periode { get; set; }
        public DateTime dateAchat { get; set; }

        public string? numeroFacture { get; set; }

        public Guid utilisateurId { get; set; }

        public Guid locationId { get; set; }

        public Guid fournisseurId { get; set; }

        public double tauxAchat { get; set; } = 1;

        public double montantTotal { get; set; }

        public string? numeroAchat { get; set; }

        public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();
    }
}
