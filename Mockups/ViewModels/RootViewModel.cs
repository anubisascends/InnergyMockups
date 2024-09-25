using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Mockups.ViewModels.Interfaces;
using Mockups.Views;
using System.Windows;

namespace Mockups.ViewModels
{
    public partial class RootViewModel : ObservableObject, IViewModel
    {
        [RelayCommand]
        private void ShowToolAssignmentsMockup()
        {
            var view = App.Host.Services.GetRequiredService<ToolAssignmentsView>();

            view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
            if(view.ShowDialog() ?? false)
            {
                var selectedMachines = view.ViewModel.Machines.Where(x => x.IsChecked).ToList();
                
                var result = "Any";

                if (selectedMachines.Count > 0)
                {
                    result = string.Join(",\r\n", selectedMachines.Select(x => $"{x.Name} [Id={x.Id}]"));
                }

                MessageBox.Show($"You selected the following machines:" +
                    $"\r\n\r\n" +
                    $"{result}" +
                    $"\r\n\r\n" +
                    $"These should now be assigned to the selected tool: {view.ViewModel.SelectedTool.Name}. If 'Any' was selected, then tool assignments for this tool should be removed.");
            }
        }
    }
}
