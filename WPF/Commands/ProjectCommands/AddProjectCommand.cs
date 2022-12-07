using System.Windows;
using Data;
using WPF.Services;
using WPF.ViewModels.ProjectViewModels;

namespace WPF.Commands.ProjectCommands
{
    public class AddProjectCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly AddProjectViewModel _viewModel;

        public AddProjectCommand(AddProjectViewModel viewModel, ApiRepository repository, INavigationService navigationService, string url)
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
                Title = _viewModel.Title,
                Wage = _viewModel.Wage,
                CustomerId = _viewModel.SelectedCustomer.Id
            };
            var projectDetails = _repository.Post(_url, project); 
            if (projectDetails.Result.StatusCode == System.Net.HttpStatusCode.Created)  
            {  
                MessageBox.Show(project.Title + " has been successfully added!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to create " + project.Title);  
            }  
            _navigationService.Navigate();
        }
    }
}