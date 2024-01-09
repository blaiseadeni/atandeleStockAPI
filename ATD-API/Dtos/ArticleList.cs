namespace ATD_API.Dtos
{
    public class ArticleList
    {
        public Guid id { get; set; }
        public string? code { get; set; }

        public string? designation { get; set; }

        public Guid familleId { get; set; }

        public string famille { get; set; }

        public string emballageGros { get; set; }

        public string emballageDetail { get; set; }

        public int stockMinimal { get; set; }

        public int quantiteDetail { get; set; }

        public DateTime created { get; set; }
    }
}
