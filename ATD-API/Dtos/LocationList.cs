namespace ATD_API.Dtos
{
    public class LocationList
    {

        public Guid Id { get; set; }
        public string? Designation { get; set; }

        public DateTime DateCreation { get; set; }
        public string Societe { get; set; }

        public string? DateCloture { get; set; }

        public bool Flag { get; set; }

        public string? Addresse { get; set; }

        public string? NumeroAchat { get; set; }

        public string? NumeroCommande { get; set; }

        public string? NumeroFacture { get; set; }

        public string? NumeroLivraison { get; set; }
    }
}
