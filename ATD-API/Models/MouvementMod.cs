namespace ATD_API.Models
{
    public class MouvementMod
    {
        public string type { get; set; }
        public string designation { get; set; }

        public Guid articleId { get; set; }

        public string article { get; set; }

        public string emballage { get; set; }

        public Guid locationId { get; set; }

        public double quantite { get; set; }

        public DateTime created { get; set; } = DateTime.Now;
    }
}
