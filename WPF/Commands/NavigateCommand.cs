using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}