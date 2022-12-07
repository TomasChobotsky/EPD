using System.Windows.Input;
using WPF.Commands;
using WPF.Commands.UserCommands;
using WPF.Services;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.UserViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; }
        
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        private string _lastName;
        public string LastName 
        { 
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            } }
        private string _userName;

        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public AddUserViewModel(ApiRepository repository, INavigationService navigationService)
        {
            CloseCommand = new NavigateCommand(navigationService);
            AddCommand = new AddUserCommand(this, repository, navigationService, "api/users");
        }
    }
}