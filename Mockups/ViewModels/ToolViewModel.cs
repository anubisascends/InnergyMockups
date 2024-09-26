using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mockups.Models;
using Mockups.ViewModels.Interfaces;
using System.Collections;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;

namespace Mockups.ViewModels
{
    public partial class ToolViewModel : ObservableObject, IViewModel
    {
        public ToolViewModel()
        {
            ToolsView = new CollectionViewSource { Source = Tools }.View;
            ToolsView.SortDescriptions.Add(new SortDescription(nameof(Tool.Type), ListSortDirection.Ascending));
            ToolsView.SortDescriptions.Add(new SortDescription(nameof(Tool.Name), ListSortDirection.Ascending));

            MachinesView = new CollectionViewSource { Source = Machines }.View;
            MachinesView.SortDescriptions.Add(new SortDescription(nameof(Machine.Type), ListSortDirection.Ascending));
            MachinesView.SortDescriptions.Add(new SortDescription(nameof(Machine.Name), ListSortDirection.Ascending));
            MachinesView.Filter = o => 
            {
                var m = o as Machine;
                var tools = SelectedTools as IList;

                if(tools is null)
                {
                    return true;
                }

                foreach (Tool tool in tools)
                {
                    if((tool.Type & m.CanUseTools) != tool.Type)
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        public IEnumerable<Tool> Tools { get; } = Tool.DefaultTools;
        public IEnumerable<Machine> Machines { get; } = Machine.DefaultMachines;
        public ICollectionView ToolsView { get; init; }
        public ICollectionView MachinesView { get; init; }

        [ObservableProperty]
        private object _SelectedTools;
        [ObservableProperty]
        private Machine _SelectedAssignMachine;
        [ObservableProperty]
        private Machine _SelectedUnassignMachine;

        [RelayCommand]
        private void OnAssignTool()
        {
            if(SelectedTools is not null)
            {
                var tools = SelectedTools as IList;

                foreach (Tool tool in tools)
                {
                    if (!tool.MachineAssignments.Contains(SelectedAssignMachine.Id))
                    {
                        var assignments = new List<int>(tool.MachineAssignments);
                        assignments.Add(SelectedAssignMachine.Id);
                        tool.MachineAssignments = assignments.ToArray();
                    }
                }
            }
        }

        [RelayCommand]
        private void OnUnassignTool()
        {
            if (SelectedTools is not null)
            {
                var tools = SelectedTools as IList;

                foreach (Tool tool in tools)
                {
                    if (tool.MachineAssignments.Contains(SelectedAssignMachine.Id))
                    {
                        var assignments = new List<int>(tool.MachineAssignments);
                        assignments.Remove(SelectedAssignMachine.Id);
                        tool.MachineAssignments = assignments.ToArray();
                    }
                }
            }
        }

        partial void OnSelectedToolsChanged(object value)
        {
            MachinesView.Refresh();
        }
    }
}
