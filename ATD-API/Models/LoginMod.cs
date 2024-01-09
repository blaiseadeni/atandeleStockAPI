namespace ATD_API.Models
{
    public class LoginMod
    {
        public string utilisateur { get; set; }
        public string pwd { get; set; }
        public Guid utilisateurId { get; set; }
        public bool state { get; set; } = false;
    }
}
