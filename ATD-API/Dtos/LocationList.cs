namespace ATD_API.Dtos
{
    public class LocationList
    {

        public Guid id { get; set; }
        public string? designation { get; set; }

        public DateTime dateCreation { get; set; }
        public string societe { get; set; }

        public string? dateCloture { get; set; }

        public bool flag { get; set; }

        public string? addresse { get; set; }

        public string? numeroAchat { get; set; }

        public string? numeroCommande { get; set; }

        public string? numeroFacture { get; set; }

        public string? numeroLivraison { get; set; }
    }
}
