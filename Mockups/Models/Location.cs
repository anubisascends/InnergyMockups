using CommunityToolkit.Mvvm.ComponentModel;

namespace Mockups.Models
{
    public partial class Location : ObservableObject
    {
        [ObservableProperty]
        private string _Name;
        [ObservableProperty]
        private bool _isSelected;
    }
}
