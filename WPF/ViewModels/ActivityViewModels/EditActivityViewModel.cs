using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using WPF.Commands;
using WPF.Commands.ActivityCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ActivityViewModels
{
    public class EditActivityViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand EditCommand { get; }
        
        public int Id { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        
        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
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
        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged();
            }
        }

        public EditActivityViewModel(ApiRepository repository, INavigationService navigationService, UserStore userStore, ActivityStore activityStore)
        {
            Id = activityStore.CurrentActivity.Id;
            Description = activityStore.CurrentActivity.Description;
            StartDate = activityStore.CurrentActivity.Start;
            EndDate = activityStore.CurrentActivity.End;
            SelectedProject = new Project {Id = activityStore.CurrentActivity.ProjectId};
            CloseCommand = new NavigateCommand(navigationService);
            EditCommand = new EditActivityCommand(this, repository, navigationService, userStore, $"api/activities/{activityStore.CurrentActivity.Id}");
            InitializeCollection(repository);
            
        }
        
        public async void InitializeCollection(ApiRepository repository)
        {
            Projects = new ObservableCollection<Project>(await repository.Get<Project>("api/projects"));
        }
    }
}