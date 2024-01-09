namespace ATD_API.Entities
{
    public class InvetaireComptable
    {
        public Guid id { get; set; }
        public DateTime date { get; set; }
        public DateTime date1 { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public Guid articleId { get; set; }
        public Guid locationId { get; set; }
        public Guid utilisateurId { get; set; }
        public double stockInit { get; set; }
        public double montantInit { get; set; }
        public double qteEnt { get; set; }
        public double montantEnt { get; set; }
        public double qteSort { get; set; }
        public double montantSort { get; set; }
        public double stockFinal { get; set; }
        public double montantFinal { get; set; }
    }
}
