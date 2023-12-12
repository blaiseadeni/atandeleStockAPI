namespace ATD_API.Entities
{
    public class PortefeuilleMod
    {
        public Guid clientId { get; set; }
        public Guid monnaieId { get; set; }
        public double montant { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
    }
}
