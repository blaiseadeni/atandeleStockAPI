namespace ATD_API.Entities
{
    public class Depense
    {
        public Guid id { get; set; }
        public string periode { get; set; }
        public Guid utilisateurId { get; set; }
        public string motif { get; set; }
        public double montant { get; set; }
        public string beneficiaire { get; set; }
        public DateTime created { get; set; }
    }
}
