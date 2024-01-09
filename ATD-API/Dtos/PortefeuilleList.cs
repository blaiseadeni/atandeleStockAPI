namespace ATD_API.Dtos
{
    public class PortefeuilleList
    {
        public Guid id { get; set; }
        public Guid clientId { get; set; }
        public string client { get; set; }
        public Guid monnaieId { get; set; }
        public string monnaie { get; set; }
        public double montant { get; set; }
        public DateTime created { get; set; }
    }
}
