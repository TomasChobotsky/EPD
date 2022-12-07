using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using WPF.Commands;
using WPF.Commands.ProjectCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ProjectViewModels
{
    public class EditProjectViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand EditCommand { get; }
        
        public int Id { get; set; }
        
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

        public EditProjectViewModel(ApiRepository repository, INavigationService navigationService, ProjectStore projectStore)
        {
            Id = projectStore.CurrentProject.Id;
            Title = projectStore.CurrentProject.Title;
            Wage = projectStore.CurrentProject.Wage;
            SelectedCustomer = new Customer {Id = projectStore.CurrentProject.CustomerId} ;
            CloseCommand = new NavigateCommand(navigationService);
            EditCommand = new EditProjectCommand(this, repository, navigationService, $"api/projects/{projectStore.CurrentProject.Id}");
            InitializeCollection(repository);
        }
        
        public async void InitializeCollection(ApiRepository repository)
        {
            Customers = new ObservableCollection<Customer>(await repository.Get<Customer>("api/customers"));
        }
    }
}