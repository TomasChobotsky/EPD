using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF.Commands;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModels.UtilityViewModels
{
    public class NavbarViewModel : ViewModelBase
    {
        public Action IsCheckedChanged;
        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateActivityCommand { get; set; }
        public ICommand NavigateCustomerCommand { get; set; }
        public ICommand NavigateProjectCommand { get; set; }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                IsCheckedChanged?.Invoke();
            }
        }

        public NavbarViewModel(INavigationService homeNavigationService,
            INavigationService activityNavigationService,
            INavigationService customerNavigationService,
            INavigationService projectNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateActivityCommand = new NavigateCommand(activityNavigationService);
            NavigateCustomerCommand = new NavigateCommand(customerNavigationService);
            NavigateProjectCommand = new NavigateCommand(projectNavigationService);
        }
    }
}