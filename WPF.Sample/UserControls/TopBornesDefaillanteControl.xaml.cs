using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for TopBornesDefaillanteControl.xaml
    /// </summary>
    public partial class TopBornesDefaillanteControl : UserControl
    {
        private TopBornesDefaillanteViewModel viewModel;

        public TopBornesDefaillanteControl()
        {
            InitializeComponent();
            viewModel = (TopBornesDefaillanteViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}