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
    }
}
