using System;
using CommunityToolkit.Mvvm.ComponentModel;
using WPF.Stores;
using WPF.ViewModels;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly UserStore _userStore;
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavbarViewModel> _createNavbarViewModel;
        private readonly INavigationService _loginNavigationService;

        public LayoutNavigationService(UserStore userStore, NavigationStore navigationStore, Func<TViewModel> createViewModel, 
            Func<NavbarViewModel> createNavbarViewModel, INavigationService loginNavigationService)
        {
            _userStore = userStore;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavbarViewModel = createNavbarViewModel;
            _loginNavigationService = loginNavigationService;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_userStore, _createNavbarViewModel(), _createViewModel(), _loginNavigationService);
        }
    }
}