using System.Windows;

namespace WPF.Commands
{
    public class ExitCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}