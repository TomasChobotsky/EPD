using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.Components
{
    public partial class Navbar : UserControl
    {
        App _current = Application.Current as App;
        public Navbar()
        {
            InitializeComponent();
            RenderTransform = new TranslateTransform();
        }
        
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && _current.MainWindow != null)
                _current.MainWindow.DragMove();
        }
    }
}