namespace ATD_API.Models
{
    public class MouvementMod
    {
        public string Type { get; set; }
        public string Designation { get; set; }

        public Guid ArticleId { get; set; }

        public string Article { get; set; }

        public string Emballage { get; set; }

        public Guid LocationId { get; set; }

        public double Quantite { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
