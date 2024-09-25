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

            foreach (var machine in Machines) 
            {
                machine.PropertyChanged += onMachinePropertyChanged;
            }

            SelectedTool = new Tool { Name = "3/8\" Compression Bit", Type = ToolType.Router | ToolType.Flat };
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
            new Machine{Name = "Biesse Rover B", Id = 0, Type = MachineType.Sheet | MachineType.Router},
            new Machine{Name = "Komo (Fanuc)", Id = 3, Type = MachineType.Sheet | MachineType.Router | MachineType.Part},
            new Machine{Name = "C. R. Onsrud CR105", Id = 0, Type = MachineType.Part},
            new Machine{Name = "Holz-Her Panel Saw", Id = 2, Type = MachineType.Saw},
        ];

        public ICollectionView MachinesView { get; init; }
        public Tool SelectedTool { get; }

        [ObservableProperty]
        private string _SelectedItems = "Any";


        [RelayCommand]
        private void OnOk()
        {
            OkClicked?.Invoke(this, EventArgs.Empty);
        }


    }
}
