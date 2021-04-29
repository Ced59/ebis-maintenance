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
        private TopElementsDefaillanteViewModel viewModel;

        public TopBornesDefaillanteControl()
        {
            InitializeComponent();
            viewModel = (TopElementsDefaillanteViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}