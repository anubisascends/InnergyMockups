using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mockups.Models;
using Mockups.ViewModels.Interfaces;
using System.ComponentModel;
using System.Windows.Data;

namespace Mockups.ViewModels
{
    public partial class ToolAssignmentsViewModel : ObservableObject, IViewModel
    {
        public event EventHandler? OkClicked;

        public ToolAssignmentsViewModel()
        {
            MachinesView = new CollectionViewSource { Source = Machines }.View;
            MachinesView.SortDescriptions.Add(new SortDescription(nameof(Machine.Type), ListSortDirection.Ascending));
            MachinesView.SortDescriptions.Add(new SortDescription(nameof(Machine.Name), ListSortDirection.Ascending));
            MachinesView.Filter = o => 
            {
                var m = o as Machine;

                return ((SelectedTool?.Type ?? (ToolType)0) & m.CanUseTools) == (SelectedTool?.Type ?? (ToolType)0);
            };

            foreach (var machine in Machines) 
            {
                machine.PropertyChanged += onMachinePropertyChanged;
            }
        }

        private void onMachinePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SelectedItems = "Any";

            var selectedMachines = Machines.Where(x => x.IsChecked).ToList();

            if (selectedMachines.Count > 0) 
            {
                SelectedItems = string.Join(", ", selectedMachines.Select(x => x.Name));
            }
        }

        public IEnumerable<Machine> Machines { get; } = [
            new Machine{Name = "Biesse Rover B", Id = 0, Type = MachineType.Sheet | MachineType.Router, CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical},
            new Machine{Name = "Komo (Fanuc)", Id = 3, Type = MachineType.Sheet | MachineType.Router | MachineType.Part, CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill},
            new Machine{Name = "C. R. Onsrud CR105", Id = 0, Type = MachineType.Part, CanUseTools = ToolType.Router | ToolType.Drill | ToolType.Vertical | ToolType.Saw},
            new Machine{Name = "Holz-Her Panel Saw", Id = 2, Type = MachineType.Saw, CanUseTools = ToolType.Saw},
        ];

        public ICollectionView MachinesView { get; init; }

        [ObservableProperty]
        private string _SelectedItems = "Any";
        [ObservableProperty]
        private Tool? _SelectedTool;


        [RelayCommand]
        private void OnOk()
        {
            OkClicked?.Invoke(this, EventArgs.Empty);
        }

        partial void OnSelectedToolChanged(Tool? value)
        {
            MachinesView.Refresh();
        }
    }
}
