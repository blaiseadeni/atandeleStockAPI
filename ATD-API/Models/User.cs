namespace jwtLogin.Models
{
    public class User
    {
        //public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
