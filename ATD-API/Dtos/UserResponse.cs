namespace ATD_API.Dtos
{
    public class UserResponse
    {
        public Guid id { get; set; }
        public string nom { get; set; }
        public string postnom { get; set; }
        public Guid locationId { get; set; }
        public string location { get; set; }
        public Guid roleId { get; set; }
        public string role { get; set; }
        public Guid loginId { get; set; }
        public string utilisateur { get; set; }
        public Guid utilisateurId { get; set; }
        public bool state { get; set; }
        public DateTime created { get; set; }
    }
}
