using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Mockups.Models;
using Mockups.ViewModels.Interfaces;
using Mockups.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Mockups.ViewModels
{
    public partial class ToolViewModel : ObservableObject, IViewModel
    {
        public ToolViewModel()
        {
            ToolsView = new CollectionViewSource { Source = Tools }.View;
            ToolsView.SortDescriptions.Add(new SortDescription(nameof(Tool.Type), ListSortDirection.Ascending));
            ToolsView.SortDescriptions.Add(new SortDescription(nameof(Tool.Name), ListSortDirection.Ascending));
        }

        public IEnumerable<Tool> Tools { get; } = [
            new Tool{ Name = "3/8\" Compression Bit", Type = ToolType.Router | ToolType.Flat, IsAvailable = true },
            new Tool{ Name = "1/2\" Downshear Bit", Type = ToolType.Router | ToolType.Flat, IsAvailable = true },
            new Tool{ Name = "5mm H-Drill", Type = ToolType.Drill | ToolType.Horizontal, IsAvailable = true },
            new Tool{ Name = "5mm V-Drill", Type = ToolType.Drill | ToolType.Vertical, IsAvailable = true },
            new Tool{ Name = "8mm Ball End", Type = ToolType.Router | ToolType.BallEnd, IsAvailable = true },
            new Tool{ Name = "Thick Kerf Blade", Type = ToolType.Saw, IsAvailable = true },
            new Tool{ Name = "Thin Kerf Blade", Type = ToolType.Saw, IsAvailable = true }
        ];

        public ICollectionView ToolsView { get; init; }

        [RelayCommand]
        private void AssignMachines(Tool parameter)
        {
            var view = App.Host.Services.GetRequiredService<ToolAssignmentsView>();

            view.ViewModel.SelectedTool = parameter;

            if (view.ShowDialog() ?? false)
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
