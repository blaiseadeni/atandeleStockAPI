namespace ATD_API.Dtos
{
    public class UtilisateurRequest
    {
        public string nom { get; set; }
        public string postnom { get; set; }
        public Guid locationId { get; set; }
        public Guid utilisateurId { get; set; }
        public Guid roleId { get; set; }
        public string utilisateur { get; set; }
    }
}
