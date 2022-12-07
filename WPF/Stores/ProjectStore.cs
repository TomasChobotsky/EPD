using System;
using Data;

namespace WPF.Stores
{
    public class ProjectStore
    {
        private Project _currentProject;
        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                _currentProject = value;
                CurrentProjectChanged?.Invoke();
            }
        }
        
        public event Action CurrentProjectChanged;
    }
}