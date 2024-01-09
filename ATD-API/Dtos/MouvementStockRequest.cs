namespace ATD_API.Dtos
{
    public class MouvementStockRequest
    {
        public Guid locationId { get; set; }
        public Guid articleId { get; set; }
        public int periode { get; set; }
    }
}
