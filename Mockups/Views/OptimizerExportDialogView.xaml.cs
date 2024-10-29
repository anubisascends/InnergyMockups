using Mockups.ViewModels;
using Mockups.Views.Interfaces;

namespace Mockups.Views
{
    /// <summary>
    /// Interaction logic for OptimizerExportDialogView.xaml
    /// </summary>
    public partial class OptimizerExportDialogView : IView<OptimizerExportDialogViewModel>
    {
        public OptimizerExportDialogView(OptimizerExportDialogViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        public OptimizerExportDialogViewModel ViewModel { get; }
    }
}
