namespace Common.Classes
{
    /// <summary>
    /// Réception et envoi de messages depuis et vers des classes qui s'y abonnent
    /// </summary>
    public class MessageBroker
    {
        /// <summary>
        /// Delegate pour le handler d'événement MessageReceived
        /// </summary>
        /// <param name="sender">L'objet ayant émis l'événement</param>
        /// <param name="e">un objet MessageBrokerEventArgs contenant le message</param>
        public delegate void MessageReceivedEventHandler(object sender, MessageBrokerEventArgs e);

        public event MessageReceivedEventHandler MessageReceived;

        /// Cette classe implémente le pattern Singleton
        private static MessageBroker _Instance;

        public static MessageBroker Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MessageBroker();
                }

                return _Instance;
            }
            set { _Instance = value; }
        }

        /// <summary>
        /// Envoie un message à tout objet abonné
        /// Le payload est ici vide (null)
        /// </summary>
        /// <param name="nomMessage">Le nom du message</param>
        public void DiffuserMessage(string nomMessage)
        {
            DiffuserMessage(nomMessage, null);
        }

        /// <summary>
        /// Envoie un message à tout objet abonné
        /// </summary>
        /// <param name="nomMessage">Le nom du message</param>
        /// <param name="payload">Le contenu du message</param>
        public void DiffuserMessage(string nomMessage, object payload)
        {
            MessageBrokerEventArgs arg;

            arg = new MessageBrokerEventArgs(nomMessage, payload);

            RaiseMessageReceived(arg);
        }

        /// <summary>
        /// Émet l'événement MessageReceived
        /// </summary>
        /// <param name="e">Un objet MessageBrokerEventArgs</param>
        protected void RaiseMessageReceived(MessageBrokerEventArgs e)
        {
            if (null != MessageReceived)
            {
                MessageReceived(this, e);
            }
        }
    }
}