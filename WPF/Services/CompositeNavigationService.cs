using System.Collections;
using System.Collections.Generic;

namespace WPF.Services
{
    public class CompositeNavigationService : INavigationService
    {
        private IEnumerable<INavigationService> _navigationServices;

        public CompositeNavigationService(params INavigationService[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate()
        {
            foreach (INavigationService navigationService in _navigationServices)
            {
                navigationService.Navigate();
            }
        }
    }
}