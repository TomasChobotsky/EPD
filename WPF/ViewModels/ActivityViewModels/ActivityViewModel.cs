using System.Collections.Generic;
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
    public class ActivityViewModel : ViewModelBase
    {
        public ActivityViewModel(ApiRepository dataRepository, INavigationService addActivityNavigationService, INavigationService editActivityNavigationService, 
            ActivityStore activityStore)
        {
            InitializeCollection(dataRepository);
            _activityStore = activityStore;
            AddCommand = new NavigateCommand(addActivityNavigationService);
            EditCommand = new NavigateCommand(editActivityNavigationService);
            DeleteCommand = new DeleteActivityCommand(dataRepository, "api/activities", this);
        }
        
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public async void InitializeCollection(ApiRepository dataRepository)
        {
            Activities = new ObservableCollection<Activity>(await dataRepository.Get<Activity>("api/activities"));
        }
        
        private ObservableCollection<Activity> _activities;

        public ObservableCollection<Activity> Activities
        {
            get => _activities;
            set
            {
                _activities = value;
                OnPropertyChanged();
            }
        }
        private Activity _selectedActivity;
        private readonly ActivityStore _activityStore;

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                _selectedActivity = value;
                _activityStore.CurrentActivity = value;
                OnPropertyChanged();
            }
        }
    }
}