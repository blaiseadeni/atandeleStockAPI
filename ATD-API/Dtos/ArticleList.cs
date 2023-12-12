namespace ATD_API.Dtos
{
    public class ArticleList
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }

        public string? Designation { get; set; }

        public Guid FamilleId { get; set; }
        public string Famille { get; set; }

        public string EmballageGros { get; set; }

        public string EmballageDetail { get; set; }

        public int StockMinimal { get; set; }

        public int QuantiteDetail { get; set; }

        public DateTime Created { get; set; }
    }
}
