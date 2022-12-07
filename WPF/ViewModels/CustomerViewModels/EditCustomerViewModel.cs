using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using WPF.Commands;
using WPF.Commands.CustomerCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.CustomerViewModels
{
    public class EditCustomerViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand EditCommand { get; }
        
        public int Id { get; set; }
        
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _address;

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }
        private string _city;

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        private string _zipCode;

        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }
        private string _ic;

        public string IC
        {
            get => _ic;
            set
            {
                _ic = value;
                OnPropertyChanged();
            }
        }
        private string _dic;

        public string DIC
        {
            get => _dic;
            set
            {
                _dic = value;
                OnPropertyChanged();
            }
        }

        public EditCustomerViewModel(ApiRepository repository, INavigationService navigationService, CustomerStore customerStore)
        {
            Id = customerStore.CurrentCustomer.Id;
            Name = customerStore.CurrentCustomer.Name;
            Address = customerStore.CurrentCustomer.Address;
            City = customerStore.CurrentCustomer.City;
            ZipCode = customerStore.CurrentCustomer.ZipCode;
            IC = customerStore.CurrentCustomer.IC;
            DIC = customerStore.CurrentCustomer.DIC;
            CloseCommand = new NavigateCommand(navigationService);
            EditCommand = new EditCustomerCommand(this, repository, navigationService, $"api/customers/{customerStore.CurrentCustomer.Id}");
        }

    }
}