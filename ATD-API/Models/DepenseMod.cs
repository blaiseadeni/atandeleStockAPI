namespace ATD_API.Models
{
    public class DepenseMod
    {
        public Guid id { get; set; }
        public string periode { get; set; } = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        public Guid utilisateurId { get; set; }
        public string motif { get; set; }
        public double montant { get; set; }
        public string beneficiaire { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
    }
}
