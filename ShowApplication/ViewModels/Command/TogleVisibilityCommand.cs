using System;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication.ViewModels.Command
{
    public class TogleVisibilityCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object window)
        {
            var mainWindow = (MainWindow)window;
            if (mainWindow.IsVisible)
            {
                mainWindow.Hide();
            }
            else
            {
               mainWindow.Show();
            }
        }
    }
}
