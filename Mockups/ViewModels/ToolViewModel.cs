using CommunityToolkit.Mvvm.ComponentModel;
using Mockups.Models;
using Mockups.ViewModels.Interfaces;
using System.Collections;
using System.ComponentModel;
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

        partial void OnSelectedToolsChanged(object value)
        {
            MachinesView.Refresh();
        }
    }
}
