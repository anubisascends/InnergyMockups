using Mockups.ViewModels.Interfaces;

namespace Mockups.Views.Interfaces
{
    public interface IView<T> where T : IViewModel
    {
        T ViewModel { get; }
    }
}
