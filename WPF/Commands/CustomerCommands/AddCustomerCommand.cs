using System.Windows;
using Data;
using WPF.Services;
using WPF.ViewModels.CustomerViewModels;

namespace WPF.Commands.CustomerCommands
{
    public class AddCustomerCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly AddCustomerViewModel _viewModel;

        public AddCustomerCommand(AddCustomerViewModel viewModel, ApiRepository repository, INavigationService navigationService, string url)
        {
            _viewModel = viewModel;
            _repository = repository;
            _navigationService = navigationService;
            _url = url;
        }

        public override void Execute(object parameter)
        {
            Customer customer = new Customer() 
            {
                Name = _viewModel.Name,
                Address = _viewModel.Address,
                City = _viewModel.City,
                ZipCode = _viewModel.ZipCode,
                IC = _viewModel.IC,
                DIC = _viewModel.DIC
            };
            var customerDetails = _repository.Post(_url, customer); 
            if (customerDetails.Result.StatusCode == System.Net.HttpStatusCode.Created)  
            {  
                MessageBox.Show(customer.Name + " has been successfully added!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to create " + customer.Name);  
            }  
            _navigationService.Navigate();
        }
    }
}