namespace ATD_API.Entities
{
    public class MouvementStock
    {
        public Guid id { get; set; }
        public Guid articleId { get; set; }
        public Guid locationId { get; set; }
        public string periode { get; set; }
        public string article { get; set; }
        public string libelle { get; set; }
        public DateTime date { get; set; }
        public double qteEntr { get; set; }
        public double puEntr { get; set; }
        public double ptEnt { get; set; }
        public double qteSort { get; set; }
        public double puSort { get; set; }
        public double ptSort { get; set; }
        public double qteSt { get; set; }
        //public double puSt { get; set; }
        //public double ptSt { get; set; }
    }
}
