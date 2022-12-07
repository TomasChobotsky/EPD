using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using Data;
using WPF.Commands;
using WPF.Commands.ActivityCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ActivityViewModels
{
    public class AddTimerActivityViewModel : ViewModelBase, IActivityViewModel
    {
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand StartTimerCommand { get; }
        public ICommand StopTimerCommand { get; }

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
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

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
        
        private string _currentTime;

        public DispatcherTimer _timer;

        public string CurrentTime
        {
            get
            {
                return this._currentTime;
            }
            set
            {
                if (_currentTime == value)
                    return;
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public AddTimerActivityViewModel(ApiRepository repository, INavigationService navigationService, UserStore userStore)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            CloseCommand = new NavigateCommand(navigationService);
            AddCommand = new AddActivityCommand(this, repository, navigationService, userStore, "api/activities");
            StartTimerCommand = new RelayCommand(StartTimer);
            StopTimerCommand = new RelayCommand(StopTimer);
            InitializeCollection(repository);
        }
        
        public async void InitializeCollection(ApiRepository repository)
        {
            Projects = new ObservableCollection<Project>(await repository.Get<Project>("api/projects"));
        }

        private void StartTimer()
        {
            StartDate = DateTime.Now;
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToLongTimeString();
            };
            _timer.Start();
        }

        private void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                EndDate = DateTime.Now;
            }
        }
    }
}