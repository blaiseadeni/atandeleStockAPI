namespace ATD_API.Dtos
{
    public class MouvementList
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Designation { get; set; }

        public Guid ArticleId { get; set; }

        public string Article { get; set; }

        public string Emballage { get; set; }

        public Guid LocationId { get; set; }

        public string Location { get; set; }

        public double Quantite { get; set; }

        public DateTime Created { get; set; }
    }
}
