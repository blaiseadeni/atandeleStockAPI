namespace ATD_API.Entities
{
    public class Login
    {
        public Guid id { get; set; }
        public string utilisateur { get; set; }
        public string pwd { get; set; }
        public Guid utilisateurId { get; set; }
        public bool state { get; set; }
    }
}
