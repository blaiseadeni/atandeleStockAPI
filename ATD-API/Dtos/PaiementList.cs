namespace ATD_API.Dtos
{
    public class PaiementList
    {
        public Guid FactureId { get; set; }
        public string numeroFacture { get; set; }

        public DateTime DatePaiement { get; set; } = DateTime.Now;

        public double MontantPayer { get; set; }
    }
}
