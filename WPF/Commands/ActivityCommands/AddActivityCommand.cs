using System.Windows;
using Data;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.ActivityViewModels;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.Commands.ActivityCommands
{
    public class AddActivityCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly IActivityViewModel _viewModel;
        private readonly UserStore _userStore;

        public AddActivityCommand(IActivityViewModel viewModel, ApiRepository repository, INavigationService navigationService, UserStore userStore, string url)
        {
            _viewModel = viewModel;
            _repository = repository;
            _navigationService = navigationService;
            _userStore = userStore;
            _url = url;
        }

        public override void Execute(object parameter)
        {
            Activity activity = new Activity() 
            {
                    Description = _viewModel.Description, 
                    Start = _viewModel.StartDate,
                    End = _viewModel.EndDate,
                    ProjectId = _viewModel.SelectedProject.Id,
                    UserId = _userStore.CurrentUser.Id
            };
            var activityDetails = _repository.Post("api/activities", activity); 
            if (activityDetails.Result.StatusCode == System.Net.HttpStatusCode.Created)  
            {  
                MessageBox.Show(activity.Description + " has been successfully added!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to create " + activity.Description);  
            }  
            _navigationService.Navigate();
        }
    }
}