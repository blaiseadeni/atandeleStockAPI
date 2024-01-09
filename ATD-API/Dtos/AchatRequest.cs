using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class AchatRequest
    {
        public DateTime dateAchat { get; set; }

        public string? numeroFacture { get; set; }

        public Guid fournisseurId { get; set; }

        public double tauxAchat { get; set; }

        public double montantTotal { get; set; }

        public string? numeroAchat { get; set; }

        public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();
    }
}
