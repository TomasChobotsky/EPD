using System;
using CommunityToolkit.Mvvm.ComponentModel;
using WPF.Stores;
using WPF.ViewModels;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.Services
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase 
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}