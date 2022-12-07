using System.Windows;
using Data;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.ActivityViewModels;

namespace WPF.Commands.ActivityCommands
{
    public class EditActivityCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly EditActivityViewModel _viewModel;
        private readonly UserStore _userStore;

        public EditActivityCommand(EditActivityViewModel viewModel, ApiRepository repository, INavigationService navigationService, UserStore userStore, string url)
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
                Id = _viewModel.Id,
                Description = _viewModel.Description, 
                Start = _viewModel.StartDate,
                End = _viewModel.EndDate,
                ProjectId = _viewModel.SelectedProject.Id,
                UserId = _userStore.CurrentUser.Id
            };
            var activityDetails = _repository.Put<Activity>(_url, activity); 
            if (activityDetails.Result.StatusCode == System.Net.HttpStatusCode.NoContent)  
            {  
                MessageBox.Show(activity.Description + " has been successfully edited!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to edit " + activity.Description);  
            }  
            _navigationService.Navigate();
        }
    }
}