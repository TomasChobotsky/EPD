using WPF.Services;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly UserStore _userStore;
        private readonly INavigationService _navigationService;

        public LogoutCommand(UserStore userStore, INavigationService navigationService)
        {
            _userStore = userStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _userStore.Logout();
            _navigationService.Navigate();
        }
    }
}