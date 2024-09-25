using CommunityToolkit.Mvvm.ComponentModel;

namespace Mockups.Models
{
    public partial class Machine : ObservableObject
    {
        [ObservableProperty]
        private string _Name;
        [ObservableProperty]
        private int _Id;
        [ObservableProperty]
        private MachineType _Type;
        [ObservableProperty]
        private bool _IsChecked;
        
        public ToolType CanUseTools { get; set; }

        public static IEnumerable<Machine> DefaultMachines { get; } = [
            new Machine{ 
                Name = "Nesting Machine", 
                Type = MachineType.Router | MachineType.Sheet, 
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical },
            new Machine{
                Name = "Nesting Machine 2",
                Type = MachineType.Router | MachineType.Sheet,
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical },
            new Machine{
                Name = "Panel Saw",
                Type = MachineType.Saw | MachineType.Sheet,
                CanUseTools = ToolType.Saw },
            new Machine{
                Name = "P2P Machine",
                Type = MachineType.Router | MachineType.Part,
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical | ToolType.Horizontal | ToolType.Saw},
        ];
    }
}
