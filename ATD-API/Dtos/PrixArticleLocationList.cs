namespace ATD_API.Dtos
{
    public class PrixArticleLocationList
    {
        public Guid id { get; set; }

        public double prixVenteDetail { get; set; }

        public double prixVenteGros { get; set; }

        public string? monnaie { get; set; }

        public Guid locationId { get; set; }

        public string location { get; set; }

        public Guid articleId { get; set; }

        public string article { get; set; }
    }
}
