using Common.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        private string messageOriginal;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowViewModel)this.Resources["viewModel"];
            MessageBroker.Instance.MessageReceived += Broker_MessageReceived;
            messageOriginal = viewModel.MsgStatut;
        }

        private void Broker_MessageReceived(object sender, MessageBrokerEventArgs e)
        {
            switch (e.MessageName)
            {
                case MessageBrokerMessages.CLOSE_USER_CONTROL:
                    FermerUserControl();
                    viewModel.MsgStatut = messageOriginal;
                    break;

                case MessageBrokerMessages.DISPLAY_STATUS_MESSAGE:
                    viewModel.MsgStatut = (String)e.MessagePayload;
                    break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = (MenuItem)sender;
            string cmd = string.Empty;

            // La propriété Tag contient soit une commande,
            // soit le nom d'un User Control à afficher
            if (menu.Tag != null)
            {
                cmd = menu.Tag.ToString();
                if (cmd.Contains("."))
                {
                    // S'il y a un '.' c'est un User Control
                    ChargerUserControl(cmd);
                }
                else
                {
                    // C'est une commande
                    TraiterCommandeMenu(cmd);
                }
            }
        }

        public void ChargerUserControl(string nomDuControl)
        {
            Type ucType = null;
            UserControl uc = null;

            if (DoitChargerUserControl(nomDuControl))
            {
                // Création d'un Type à partir de la string en paramètre
                ucType = Type.GetType(nomDuControl);
                if (ucType == null)
                {
                    MessageBox.Show("Le Control : " + nomDuControl + " est inconnu.");
                }
                else
                {
                    // Fermeture du User Control courant
                    FermerUserControl();

                    // Création réflexive d'une instance du Control demandé
                    uc = (UserControl)Activator.CreateInstance(ucType);
                    if (uc != null)
                    {
                        // Affichage du Control dans la zone de contenu
                        AfficherUserControl(uc);
                    }
                }
            }
        }

        public void TraiterCommandeMenu(string cmd)
        {
            switch (cmd)
            {
                case "Fermer":
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        public void AfficherUserControl(UserControl uc)
        {
            zoneDeContenu.Children.Add(uc);
        }

        public bool DoitChargerUserControl(string nomDuControl)
        {
            if (zoneDeContenu.Children.Count > 0 && ((UserControl)zoneDeContenu.Children[0]).GetType().FullName == nomDuControl)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void FermerUserControl()
        {
            zoneDeContenu.Children.Clear();
        }
    }
}