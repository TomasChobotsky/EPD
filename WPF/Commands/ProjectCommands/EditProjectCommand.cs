using System.Windows;
using Data;
using WPF.Services;
using WPF.ViewModels.ProjectViewModels;

namespace WPF.Commands.ProjectCommands
{
    public class EditProjectCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly EditProjectViewModel _viewModel;

        public EditProjectCommand(EditProjectViewModel viewModel, ApiRepository repository, INavigationService navigationService, string url)
        {
            _viewModel = viewModel;
            _repository = repository;
            _navigationService = navigationService;
            _url = url;
        }

        public override void Execute(object parameter)
        {
            Project project = new Project() 
            {
                Id = _viewModel.Id,
                Title = _viewModel.Title,
                Wage = _viewModel.Wage,
                CustomerId = _viewModel.SelectedCustomer.Id
            };
            var projectDetails = _repository.Put(_url, project); 
            if (projectDetails.Result.StatusCode == System.Net.HttpStatusCode.NoContent)  
            {  
                MessageBox.Show(project.Title + " has been successfully edited!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to edit " + project.Title);  
            }  
            _navigationService.Navigate();
        }
    }
}