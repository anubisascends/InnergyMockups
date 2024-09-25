using CommunityToolkit.Mvvm.ComponentModel;

namespace Mockups.Models
{
    public partial class ToolAssignment : ObservableObject
    {
        [ObservableProperty]
        private int _ToolId;
        [ObservableProperty]
        private int _MachineId;
    }
}
