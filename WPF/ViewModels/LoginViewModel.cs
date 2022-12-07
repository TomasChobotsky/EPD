using System.Security;
using System.Windows.Input;
using WPF.Commands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel(UserStore userStore, INavigationService homeNavigationService, INavigationService userNavigationService, ApiAuthRepository userDataRepository)
        {
            LoginCommand = new LoginCommand(this, homeNavigationService, userStore, userDataRepository);
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password 
        { 
            get => password; 
            set
            {
                password = value;
                OnPropertyChanged();
            } 
        }
    }
}