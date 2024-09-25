using Mockups.ViewModels;
using Mockups.Views.Interfaces;

namespace Mockups.Views
{
    /// <summary>
    /// Interaction logic for ToolAssignmentsView.xaml
    /// </summary>
    public partial class ToolAssignmentsView : IView<ToolAssignmentsViewModel>
    {
        public ToolAssignmentsView(ToolAssignmentsViewModel viewModel)
        {

            ViewModel = viewModel;

            viewModel.OkClicked += onOkClicked;

            DataContext = this;
            InitializeComponent();
        }

        private void onOkClicked(object? sender, EventArgs e)
        {
            DialogResult = true;
        }

        public ToolAssignmentsViewModel ViewModel { get; }
    }
}
