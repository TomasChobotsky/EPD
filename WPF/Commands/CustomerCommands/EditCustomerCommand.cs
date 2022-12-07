using System.Windows;
using Data;
using WPF.Services;
using WPF.ViewModels.CustomerViewModels;

namespace WPF.Commands.CustomerCommands
{
    public class EditCustomerCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly INavigationService _navigationService;
        private readonly EditCustomerViewModel _viewModel;

        public EditCustomerCommand(EditCustomerViewModel viewModel, ApiRepository repository, INavigationService navigationService, string url)
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
                Id = _viewModel.Id,
                Name = _viewModel.Name,
                Address = _viewModel.Address,
                City = _viewModel.City,
                ZipCode = _viewModel.ZipCode,
                IC = _viewModel.IC,
                DIC = _viewModel.DIC
            };
            var customerDetails = _repository.Put(_url, customer); 
            if (customerDetails.Result.StatusCode == System.Net.HttpStatusCode.NoContent)  
            {  
                MessageBox.Show(customer.Name + " has been successfully edited!");  
            }  
            else  
            {  
                MessageBox.Show("Failed to edit " + customer.Name);  
            }  
            _navigationService.Navigate();
        }
    }
}