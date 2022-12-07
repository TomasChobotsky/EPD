using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using WPF.Commands;
using WPF.Commands.ProjectCommands;
using WPF.Services;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ProjectViewModels
{
    public class AddProjectViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; }
        
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _wage;
        public int Wage
        {
            get => _wage;
            set
            {
                _wage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public AddProjectViewModel(ApiRepository repository, INavigationService navigationService)
        {
            CloseCommand = new NavigateCommand(navigationService);
            AddCommand = new AddProjectCommand(this, repository, navigationService, "api/projects");
            InitializeCollection(repository);
        }
        
        public async void InitializeCollection(ApiRepository repository)
        {
            Customers = new ObservableCollection<Customer>(await repository.Get<Customer>("api/customers"));
        }
    }
}