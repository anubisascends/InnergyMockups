using Mockups.ViewModels;
using Mockups.Views.Interfaces;

namespace Mockups.Views
{
    /// <summary>
    /// Interaction logic for ToolView.xaml
    /// </summary>
    public partial class ToolView : IView<ToolViewModel>
    {
        public ToolView(ToolViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        public ToolViewModel ViewModel { get; }
    }
}
