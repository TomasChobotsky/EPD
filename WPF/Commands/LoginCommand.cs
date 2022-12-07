using System.Windows;
using Data;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly INavigationService _navigationService;
        private readonly UserStore _userStore;
        private ApiAuthRepository _dataRepository;

        public LoginCommand(LoginViewModel viewModel, INavigationService navigationService, UserStore userStore, ApiAuthRepository dataRepository)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            _userStore = userStore;
            _dataRepository = dataRepository;
        }

        public override async void Execute(object parameter)
        {
            _dataRepository.SetAuthorizationHeader(_viewModel.Username, _viewModel.Password); 
            if (_dataRepository.CheckCredentials("api/users"))
            {
                _userStore.CurrentUser = await _dataRepository.Get<User>("api/users");
                _navigationService.Navigate();   
            }
            else 
                MessageBox.Show("Invalid username or password");
        }
    }
}