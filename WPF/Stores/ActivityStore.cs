using System;
using Data;

namespace WPF.Stores
{
    public class ActivityStore
    {
        private Activity _currentActivity;
        public Activity CurrentActivity
        {
            get { return _currentActivity; }
            set
            {
                _currentActivity = value;
                CurrentActivityChanged?.Invoke();
            }
        }
        
        public event Action CurrentActivityChanged;
    }
}