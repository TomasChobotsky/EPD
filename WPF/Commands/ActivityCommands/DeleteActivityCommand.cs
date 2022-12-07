using Data;
using WPF.Services;
using WPF.ViewModels.ActivityViewModels;

namespace WPF.Commands.ActivityCommands
{
    public class DeleteActivityCommand : CommandBase
    {
        private readonly ApiRepository _repository;
        private readonly string _url;
        private readonly int _id;
        private readonly ActivityViewModel _activityViewModel;

        public DeleteActivityCommand(ApiRepository repository, string url, ActivityViewModel activityViewModel)
        {
            _repository = repository;
            _url = url;
            _activityViewModel = activityViewModel;
        }

        public override void Execute(object parameter)
        {
            _repository.Delete($"{_url}/{_activityViewModel.SelectedActivity.Id}");
            _activityViewModel.Activities.Remove(_activityViewModel.SelectedActivity);
        }
    }
}