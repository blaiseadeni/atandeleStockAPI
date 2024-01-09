namespace ATD_API.Dtos
{
    public class InvComtpableResponse
    {
        public Guid articleId { get; set; }
        public string article { get; set; }
        public double qteEnt { get; set; }
        public double qteSort { get; set; }
        public double montantEnt { get; set; }
        public double montantSort { get; set; }
        public double stockFinal { get; set; }
        public double montantFinal { get; set; }
        public double stockInitial { get; set; }
        public double montantInitial { get; set; }
        public string emballage { get; set; }
    }
}
