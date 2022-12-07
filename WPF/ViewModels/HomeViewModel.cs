using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using WPF.Commands;
using WPF.Commands.ReportCommands;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels.UtilityViewModels;

namespace WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly UserStore _userStore;
        public ICommand SouhrnyReportCommand { get; }
        public ICommand DetailniReportCommand { get; }

        public string FirstName
        {
            get => _userStore.CurrentUser?.FirstName;
            set => _userStore.CurrentUser.FirstName = value;
        }
        public string LastName
        {
            get => _userStore.CurrentUser?.LastName;
            set => _userStore.CurrentUser.LastName = value;
        }
        
        public HomeViewModel(UserStore userStore, ApiRepository apiRepository)
        {
            _userStore = userStore;

            SouhrnyReportCommand = new SouhrnyReportCommand(apiRepository);
            DetailniReportCommand = new DetailniReportCommand(apiRepository);
            
            _userStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
        }

        public override void Dispose()
        {
            _userStore.CurrentUserChanged -= OnCurrentUserChanged;
            
            base.Dispose();
        }
    }
}