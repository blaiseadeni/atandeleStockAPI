namespace ATD_API.Entities
{
    public class Utilisateur
    {
        public Guid id { get; set; }
        public string nom { get; set; }
        public string postnom { get; set; }
        public Guid locationId { get; set; }
        public Guid roleId { get; set; }
        public DateTime created { get; set; }

    }
}
