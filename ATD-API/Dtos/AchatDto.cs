using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class AchatDto
    {
       

        public DateTime dateAchat { get; set; }

        public string? numeroFacture { get; set; }

        public Guid utilisateurId { get; set; }

        public Guid locationId { get; set; }

        public Guid fournisseurId { get; set; }

        public double montantTotal { get; set; }

        public virtual ICollection<DetailAchat> detailAchats { get; set; } = new List<DetailAchat>();
    }
}
