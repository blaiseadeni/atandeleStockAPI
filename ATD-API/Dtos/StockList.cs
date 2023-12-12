namespace ATD_API.Dtos
{
    public class StockList
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string Article { get; set; }
        public Guid LocationId { get; set; }
        public string Location { get; set; }
        public double Quantite { get; set; }
        public double Seuil { get; set; }
    }
}
