using Microsoft.Extensions.Hosting;
using Mockups.ViewModels;
using Mockups.Views.Interfaces;

namespace Mockups.Views
{
    /// <summary>
    /// Interaction logic for RootView.xaml
    /// </summary>
    public partial class RootView : IView<RootViewModel>, IHostedService
    {
        public RootView(RootViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        public RootViewModel ViewModel { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Show();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Close();
            return Task.CompletedTask;
        }
    }
}
