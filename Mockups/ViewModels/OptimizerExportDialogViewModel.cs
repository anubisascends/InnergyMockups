using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mockups.Models;
using Mockups.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace Mockups.ViewModels
{
    public partial class OptimizerExportDialogViewModel : ObservableObject, IViewModel
    {
        public ObservableCollection<Location> Locations { get; } = 
            [
                new (){ Name = "Room 101"},
                new (){ Name = "Room 102"},
            new (){ Name = "Room 103"},
            new (){ Name = "Print Area"},
            new (){ Name = "Hydration Station"},
            ];

        [RelayCommand]
        private void OnToggleAll()
        {
            foreach (var item in Locations)
            {
                item.IsSelected = !item.IsSelected;
            }
        }
    }
}
