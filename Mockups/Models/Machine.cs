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
                Id = 0,
                Name = "Nesting Machine", 
                Type = MachineType.Router | MachineType.Sheet, 
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical },
            new Machine{
                Id = 1,
                Name = "Nesting Machine 2",
                Type = MachineType.Router | MachineType.Sheet,
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical },
            new Machine{
                Id = 2,
                Name = "Panel Saw",
                Type = MachineType.Saw | MachineType.Sheet,
                CanUseTools = ToolType.Saw },
            new Machine{
                Id = 3,
                Name = "P2P Machine",
                Type = MachineType.Router | MachineType.Part,
                CanUseTools = ToolType.Router | ToolType.Flat | ToolType.BallEnd | ToolType.Drill | ToolType.Vertical | ToolType.Horizontal | ToolType.Saw},
        ];
    }
}
