using ATD_API.Entities;

namespace ATD_API.Dtos
{
    public class FactureRequest
    {
    

        public Guid locationId { get; set; }

        public Guid utilisateurId { get; set; }

        public string? client { get; set; }

        public Guid clientId { get; set; }

        public double remise { get; set; }

        public double totalHt { get; set; }

        public double montantPayer { get; set; }

        public double resteApayer { get; set; }

        public string? paiement { get; set; }

        public string status { get; set; }

        public double montantPortefeuille { get; set; }

        public virtual ICollection<DetailFacture> detailFactures { get; set; } = new List<DetailFacture>();
    }
}
