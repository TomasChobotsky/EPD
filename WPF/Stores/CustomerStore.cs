using System;
using Data;

namespace WPF.Stores
{
    public class CustomerStore
    {
        private Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;
                CurrentCustomerChanged?.Invoke();
            }
        }
        
        public event Action CurrentCustomerChanged;
    }
}