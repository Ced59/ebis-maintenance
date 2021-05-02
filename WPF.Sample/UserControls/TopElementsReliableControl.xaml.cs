using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for TopElementsReliableControl.xaml
    /// </summary>
    public partial class TopElementsReliableControl : UserControl
    {
        private TopElementsReliableViewModel viewModel;

        public TopElementsReliableControl()
        {
            InitializeComponent();
            viewModel = (TopElementsReliableViewModel)this.Resources["viewModel"];
            viewModel.getElementReliable();
        }

    }
}