using System;
using System.Diagnostics;
using System.Linq;
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
                WakeUp(mainWindow);
            }
        }

        internal void WakeUp(MainWindow mainWindow)
        {
            mainWindow.Show();
            mainWindow.Activate();
            PopulateSearchBox(mainWindow);
        }

        private void PopulateSearchBox(MainWindow mainWindow)
        {
            mainWindow.SearchBox.AutoSuggestionList.Clear();

            mainWindow.SearchBox.Text = string.Empty;

            foreach (Process item in Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero))
            {
                if (!mainWindow.SearchBox.AutoSuggestionList.Contains(item.ProcessName))
                {
                    mainWindow.SearchBox.AutoSuggestionList.Add(item.ProcessName);
                }
            }
        }
    }
}
