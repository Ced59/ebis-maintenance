using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for EntretienControl.xaml
    /// </summary>
    public partial class EntretienControl : UserControl
    {
        private EntretienViewModel viewModel;

        public EntretienControl()
        {
            InitializeComponent();
            viewModel = (EntretienViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}