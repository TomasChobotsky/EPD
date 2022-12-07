using System;
using Data;

namespace WPF.Stores
{
    public class UserStore
    {
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            }
        }
        
        public bool IsLoggedIn => CurrentUser != null;

        public event Action CurrentUserChanged;

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}