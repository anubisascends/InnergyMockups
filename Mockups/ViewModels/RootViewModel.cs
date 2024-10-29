using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mockups.ViewModels.Interfaces;
using Mockups.Views;
using System.Windows;

namespace Mockups.ViewModels
{
    public partial class RootViewModel : ObservableObject, IViewModel { 

        [RelayCommand]
        private void ShowToolAssignmentsMockup()
        {
            var view = App.Host.Services.GetRequiredService<ToolView>();
            view.ShowDialog();
            
        }

        [RelayCommand]
        private void ShowOptimizerExportDialog()
        {
            var view = App.Host.Services.GetRequiredService<OptimizerExportDialogView>();

            view.ShowDialog();
        }
    }
}
