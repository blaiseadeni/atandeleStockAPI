namespace ATD_API.Models
{
    public class DepenseMod
    {
        public Guid Id { get; set; }
        public string Motif { get; set; }
        public double Montant { get; set; }
        public string Beneficiaire { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
