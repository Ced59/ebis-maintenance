namespace Common.Classes
{
    /// <summary>
    /// Classe encapsulant un message de validation correspondant à une propriété
    /// (utilisée par les View Models)
    /// </summary>
    public class MessageValidation : Base
    {
        private string nomPropriete;
        private string message;

        public string NomPropriete
        {
            get { return nomPropriete; }
            set
            {
                nomPropriete = value;
                RaisePropertyChanged("NomPropriete");
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged("Message");
            }
        }
    }
}