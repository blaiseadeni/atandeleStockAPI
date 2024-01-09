namespace ATD_API.Dtos
{
    public class StockList
    {
        public Guid id { get; set; }
        public Guid articleId { get; set; }
        public string article { get; set; }
        public Guid locationId { get; set; }
        public string location { get; set; }
        public double quantite { get; set; }
        public double seuil { get; set; }
    }
}
