namespace ATD_API.Entities
{
    public class Utilisateur
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Postnom { get; set; }
        public Guid LocationId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime Created { get; set; }

    }
}
