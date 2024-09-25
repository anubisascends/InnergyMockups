using CommunityToolkit.Mvvm.ComponentModel;

namespace Mockups.Models
{
    public partial class Tool : ObservableObject
    {
        [ObservableProperty]
        private string _Name = "New Flat Router";
        [ObservableProperty]
        private ToolType _Type = ToolType.Router | ToolType.Flat;
        [ObservableProperty]
        private bool _IsAvailable;
    }
}
