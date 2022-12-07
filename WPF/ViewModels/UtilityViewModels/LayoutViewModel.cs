using System.Windows;
using System.Windows.Input;
using WPF.Commands;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModels.UtilityViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavbarViewModel NavbarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private bool _isOpen;

        public bool IsOpen 
        { 
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        }
        public LayoutViewModel(UserStore userStore, NavbarViewModel navbarViewModel, ViewModelBase contentViewModel, INavigationService loginNavigationService)
        {
            NavbarViewModel = navbarViewModel;
            ContentViewModel = contentViewModel;
            IsOpen = navbarViewModel.IsChecked;
            navbarViewModel.IsCheckedChanged += IsCheckedChanged;
            LogoutCommand = new LogoutCommand(userStore, loginNavigationService);
            ExitCommand = new ExitCommand();
        }

        public override void Dispose()
        {
            ContentViewModel.Dispose();
            NavbarViewModel.Dispose();
            
            base.Dispose();
        }

        private void IsCheckedChanged()
        {
            IsOpen = NavbarViewModel.IsChecked;
        }
    }
}