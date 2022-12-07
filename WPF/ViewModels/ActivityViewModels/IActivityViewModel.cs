using System;
using Data;
using WPF.Services;

namespace WPF.ViewModels.ActivityViewModels
{
    public interface IActivityViewModel
    {
        void InitializeCollection(ApiRepository repository);
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        Project SelectedProject { get; set; }
    }
}