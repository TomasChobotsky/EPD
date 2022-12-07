using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data;
using WPF.Commands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels.ActivityViewModels
{
    public class AddActivityViewModel : ViewModelBase
    {
        public ICommand NormalCommand { get; }
        public ICommand TimerCommand { get; }

        public AddActivityViewModel(INavigationService addNormalActivityNavigationService, INavigationService addTimerActivityNavigationService, INavigationService navigationService)
        {
            NormalCommand = new NavigateCommand(addNormalActivityNavigationService);
            TimerCommand = new NavigateCommand(addTimerActivityNavigationService);
        }
    }
}
