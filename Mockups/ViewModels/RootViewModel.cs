using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Mockups.ViewModels.Interfaces;
using Mockups.Views;

namespace Mockups.ViewModels
{
    public partial class RootViewModel : ObservableObject, IViewModel
    {
        [RelayCommand]
        private void ShowToolAssignmentsMockup()
        {
            var view = App.Host.Services.GetRequiredService<ToolAssignmentsView>();

            view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            view.ShowDialog();
        }
    }
}
