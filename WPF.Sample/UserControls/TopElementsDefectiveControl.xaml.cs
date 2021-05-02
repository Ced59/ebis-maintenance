using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for TopElementsDefectiveControl.xaml
    /// </summary>
    public partial class TopElementsDefectiveControl : UserControl
    {
        private TopElementsDefectiveViewModel viewModel;

        public TopElementsDefectiveControl()
        {
            InitializeComponent();
            viewModel = (TopElementsDefectiveViewModel)this.Resources["viewModel"];
            viewModel.getElementDefective();
        }

    }
}