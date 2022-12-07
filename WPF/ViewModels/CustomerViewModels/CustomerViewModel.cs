using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using WPF.Commands;
using WPF.Commands.CustomerCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.CustomerViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public CustomerViewModel(ApiRepository dataRepository, INavigationService addCustomerNavigationService, INavigationService editCustomerNavigationService, CustomerStore customerStore)
        {
            InitializeCollection(dataRepository);
            AddCommand = new NavigateCommand(addCustomerNavigationService);
            EditCommand = new NavigateCommand(editCustomerNavigationService);
            DeleteCommand = new DeleteCustomerCommand(dataRepository, "api/customers", this);
            _customerStore = customerStore;
        }

        private async void InitializeCollection(ApiRepository dataRepository)
        {
            Customers = new ObservableCollection<Customer>(await dataRepository.Get<Customer>("api/customers"));
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
        private readonly CustomerStore _customerStore;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                _customerStore.CurrentCustomer = value;
                OnPropertyChanged();
            }
        }
    }
}