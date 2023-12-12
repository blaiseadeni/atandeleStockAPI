namespace ATD_API.Dtos
{
    public class PrixArticleLocationList
    {
        public Guid Id { get; set; }

        public double PrixVenteDetail { get; set; }

        public double PrixVenteGros { get; set; }

        public string? Monnaie { get; set; }

        public Guid LocationId { get; set; }

        public string Location { get; set; }

        public Guid ArticleId { get; set; }

        public string Article { get; set; }
    }
}
