using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using WPF.Commands;
using WPF.Commands.ProjectCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ProjectViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ProjectViewModel(ApiRepository dataRepository, INavigationService addProjectNavigationService, INavigationService editProjectNavigationService, ProjectStore projectStore)
        {
            InitializeCollection(dataRepository);
            AddCommand = new NavigateCommand(addProjectNavigationService);
            EditCommand = new NavigateCommand(editProjectNavigationService);
            DeleteCommand = new DeleteProjectCommand(dataRepository, "api/projects", this);
            _projectStore = projectStore;
        }

        public async void InitializeCollection(ApiRepository dataRepository)
        {
            Projects = new ObservableCollection<Project>(await dataRepository.Get<Project>("api/projects"));
        }
        
        private ObservableCollection<Project> _projects;

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }
        
        private Project _selectedProject;
        private readonly ProjectStore _projectStore;

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                _projectStore.CurrentProject = value;
                OnPropertyChanged();
            }
        }
    }
}