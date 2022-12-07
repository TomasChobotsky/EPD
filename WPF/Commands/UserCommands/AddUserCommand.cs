using System.Windows;
using Data;
using WPF.Services;
using WPF.ViewModels.ActivityViewModels;
using WPF.ViewModels.UserViewModels;

namespace WPF.Commands.UserCommands
{
    public class AddUserCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly AddUserViewModel _viewModel;

        public AddUserCommand(AddUserViewModel viewModel, ApiRepository repository, INavigationService navigationService, string url)
        {
            _viewModel = viewModel;
            _repository = repository;
            _navigationService = navigationService;
            _url = url;
        }

        public override void Execute(object parameter)
        {
            User user = new User() 
            {
                FirstName = _viewModel.FirstName,
                LastName = _viewModel.LastName,
                Username = _viewModel.Username,
                Password = _viewModel.Password
            };
            var userDetails = _repository.Post("api/users", user); 
            if (userDetails.Result.StatusCode == System.Net.HttpStatusCode.Created)  
            {  
                MessageBox.Show(user.Username + " has been successfully added!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to create " + user.Username);  
            }  
            _navigationService.Navigate();
        }
    }
}