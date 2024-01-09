namespace ATD_API.Entities
{
    public class Mouvement
    {
        public Guid id { get; set; }

        public string type { get; set; }

        public string designation { get; set; }

        public Guid articleId { get; set; }

        public string article { get; set; }

        public string emballage { get; set; }

        public Guid locationId { get; set; }

        public double quantite { get; set; }

        public DateTime created { get; set; }

        //  public virtual Article Article { get; set; } = null!;

        //  public virtual Location Location { get; set; } = null!;
    }
}
