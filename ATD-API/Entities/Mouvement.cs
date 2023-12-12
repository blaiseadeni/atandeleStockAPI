namespace ATD_API.Entities
{
    public class Mouvement
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Designation { get; set; }

        public Guid ArticleId { get; set; }

        public string Article { get; set; }

        public string Emballage { get; set; }

        public Guid LocationId { get; set; }

        public float Quantite { get; set; }

        public DateTime Created { get; set; }

        //  public virtual Article Article { get; set; } = null!;

        //  public virtual Location Location { get; set; } = null!;
    }
}
