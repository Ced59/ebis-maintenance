namespace API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie
{
    public class Usager : ModelBase
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string CodePostal { get; set; }

        public string TelFixe { get; set; }

        public string TelMobile { get; set; }

        public Contrat Contrat { get; set; }
    }
}