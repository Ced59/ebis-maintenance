using Common.Classes;

namespace WPF.MonAppli.CoucheViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string menuHeaderConnexion = "Connexion";
        private string msgStatut;

        public string MenuHeaderConnexion
        {
            get { return menuHeaderConnexion; }
            set
            {
                menuHeaderConnexion = value;
                RaisePropertyChanged("MenuHeaderConnexion");
            }
        }

        public string MsgStatut
        {
            get { return msgStatut; }
            set
            {
                msgStatut = value;
                RaisePropertyChanged("MsgStatut");
            }
        }
    }
}