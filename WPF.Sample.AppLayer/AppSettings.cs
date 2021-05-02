using Common.Classes;
using WPF.MonAppli.CoucheDonnees;

namespace WPF.MonAppli.CoucheMetier
{
    /// <summary>
    /// Paramètres globaux spécifiques à l'application
    /// Implémente le pattern Singleton : une seule instance autorisée
    /// </summary>
    public class AppSettings : ConfigurationSettings
    {
        private static AppSettings _Instance;

        public static AppSettings Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AppSettings();
                }

                return _Instance;
            }
            set { _Instance = value; }
        }

        private Utilisateur entiteUtilisateur = new Utilisateur();
        private int timeoutMsgInfo;
        private string domaineEmail;

        public Utilisateur EntiteUtilisateur
        {
            get { return entiteUtilisateur; }
            set
            {
                entiteUtilisateur = value;
                RaisePropertyChanged("EntiteUtilisateur");
            }
        }

        public int TimeoutMsgInfo
        {
            get { return timeoutMsgInfo; }
            set
            {
                timeoutMsgInfo = value;
                RaisePropertyChanged("TimeoutMsgInfo");
            }
        }

        public string DomaineEmail
        {
            get { return domaineEmail; }
            set
            {
                domaineEmail = value;
                RaisePropertyChanged("DomaineEmail");
            }
        }

        public override void ChargerParametres()
        {
            TimeoutMsgInfo = GetSetting<int>("TimeoutMsgInfo", 1200);
            DomaineEmail = GetSetting<string>("DomaineEmail", "");
        }
    }
}