namespace ATD_API.Entities
{
    public class PortefeuilleMod
    {
        public Guid clientId { get; set; }
        public string periode { get; set; } = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        //public Guid monnaieId { get; set; }
        public Guid utilisateurId { get; set; }
        public double montant { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
    }
}
