namespace ATD_API.Entities
{
    public class Portefeuille
    {
        public Guid Id { get; set; }
        public Guid clientId { get; set; }
        public Guid monnaieId { get; set; }
        public double montant { get; set; }
        public DateTime created { get; set; }

        public virtual Monnaie monnaie { get; set; }
    }
}
