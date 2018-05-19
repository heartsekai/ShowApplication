using System;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    public class TogleVisibilityCommand : ICommand
    {
        public TogleVisibilityCommand(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public MainWindow MainWindow { get; }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.MainWindow.IsVisible)
            {
                this.MainWindow.Hide();
            }
            else
            {
                this.MainWindow.Show();
            }
        }
    }
}
