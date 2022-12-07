using WPF.Services;
using WPF.ViewModels.ActivityViewModels;
using WPF.ViewModels.CustomerViewModels;

namespace WPF.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly CustomerViewModel _customerViewModel;

        public DeleteCustomerCommand(ApiRepository repository, string url, CustomerViewModel customerViewModel)
        {
            _repository = repository;
            _url = url;
            _customerViewModel = customerViewModel;
        }

        public override void Execute(object parameter)
        {
            _repository.Delete($"{_url}/{_customerViewModel.SelectedCustomer.Id}");
            _customerViewModel.Customers.Remove(_customerViewModel.SelectedCustomer);
        }
    }
}