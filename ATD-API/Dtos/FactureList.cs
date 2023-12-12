using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class FactureList
    {
        public Guid Id { get; set; }
        public string? NumeroFacture { get; set; }

        public Guid LocationId { get; set; }

        public DateTime DateFacture { get; set; }

        public string? Client { get; set; }

        public double Taux { get; set; }

        public double Remise { get; set; }

        public double TotalHt { get; set; }

        public double TotalTtc { get; set; }

        public double MontantPayer { get; set; }

        public double ResteApayer { get; set; }

        public string? Monnaie { get; set; }

        public string? MontantLettre { get; set; }

        public string? Paiement { get; set; }

        public string Status { get; set; }

        public virtual ICollection<DetailFacture> DetailFactures { get; set; } = new List<DetailFacture>();
    }
}
