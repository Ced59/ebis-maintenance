using System;
using System.Collections.ObjectModel;

namespace Common.Classes
{
    /// <summary>
    /// Classe de base pour tous les View Models.
    /// Maintient  une liste de ValidationMessage pour les problèmes de validation inhérents à ce View Model. 
    /// Utilise le MessageBroker pour passer des messages standards ou pour fermer un UserControl.
    /// </summary>
    public class ViewModelBase : Base
    {
        private ObservableCollection<MessageValidation> messagesValidation = new ObservableCollection<MessageValidation>();
        private bool validationVisible = false;

        public ObservableCollection<MessageValidation> MessagesValidation
        {
            get { return messagesValidation; }
            set
            {
                messagesValidation = value;
                RaisePropertyChanged("MessagesValidation");
            }
        }

        public bool ValidationVisible
        {
            get { return validationVisible; }
            set
            {
                validationVisible = value;
                RaisePropertyChanged("ValidationVisible");
            }
        }

        public virtual void AjouterMessageValidation(string nomPropriete, string msg)
        {
            messagesValidation.Add(new MessageValidation { Message = msg, NomPropriete = nomPropriete });
            ValidationVisible = true;
        }

        public virtual void Clear()
        {
            MessagesValidation.Clear();
            ValidationVisible = false;
        }

        public virtual void AfficherMessageStatut(string msg = "")
        {
            MessageBroker.Instance.DiffuserMessage(MessageBrokerMessages.DISPLAY_STATUS_MESSAGE, msg);
        }

        public void PublishException(Exception ex)
        {
            ExceptionManager.Instance.Publish(ex);
        }

        public virtual void Fermer(bool annulation = true)
        {
            MessageBroker.Instance.DiffuserMessage(MessageBrokerMessages.CLOSE_USER_CONTROL, annulation);
        }

        public virtual void Dispose()
        {
        }
    }
}