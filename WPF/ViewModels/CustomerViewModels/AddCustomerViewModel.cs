using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using WPF.Commands;
using WPF.Commands.CustomerCommands;
using WPF.Services;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.CustomerViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; }
        
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

        public AddCustomerViewModel(ApiRepository repository, INavigationService navigationService)
        {
            CloseCommand = new NavigateCommand(navigationService);
            AddCommand = new AddCustomerCommand(this, repository, navigationService, "api/customers");
        }

    }
}