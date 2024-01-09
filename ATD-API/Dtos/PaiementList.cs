namespace ATD_API.Dtos
{
    public class PaiementList
    {
        public Guid factureId { get; set; }
        public string numeroFacture { get; set; }

        public DateTime datePaiement { get; set; } = DateTime.Now;

        public double montantPayer { get; set; }
    }
}
