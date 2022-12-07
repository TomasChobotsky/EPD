using WPF.Services;
using WPF.ViewModels.ProjectViewModels;

namespace WPF.Commands.ProjectCommands
{
    public class DeleteProjectCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly int _id;
        private readonly ProjectViewModel _projectViewModel;

        public DeleteProjectCommand(ApiRepository repository, string url, ProjectViewModel projectViewModel)
        {
            _repository = repository;
            _url = url;
            _projectViewModel = projectViewModel;
        }

        public override void Execute(object parameter)
        {
            _repository.Delete($"{_url}/{_projectViewModel.SelectedProject.Id}");
            _projectViewModel.Projects.Remove(_projectViewModel.SelectedProject);
        }
    }
}