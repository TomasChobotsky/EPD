using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels.UserViewModels;

namespace WPF.Views.UserViews
{
    public partial class AddUserView : UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
        }
        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                ((AddUserViewModel)DataContext).Password = ((PasswordBox)sender).Password;
        }
    }
}