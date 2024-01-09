namespace ATD_API.Entities
{
    public class Portefeuille
    {
        public Guid id { get; set; }
        public string periode { get; set; } 
        public Guid utilisateurId { get; set; }
        public Guid clientId { get; set; }
        //public Guid monnaieId { get; set; }
        public double montant { get; set; }
        public DateTime created { get; set; }

        //public virtual Monnaie monnaie { get; set; }
    }
}
