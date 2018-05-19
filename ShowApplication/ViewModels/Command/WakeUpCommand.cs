using ShowApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace ShowApplication.ViewModels.Command
{
    class WakeUpCommand : ICommand
    {
        public WakeUpCommand(MainWindow mainWindow)
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
            WakeUp();
        }

        internal void WakeUp()
        {
            MainWindow.Show();
            PopulateSearchBox();
        }

        private void PopulateSearchBox()
        {
            foreach (Process item in Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero))
            {
                if (!MainWindow.SearchBox.AutoSuggestionList.Contains(item.ProcessName))
                {
                    MainWindow.SearchBox.AutoSuggestionList.Add(item.ProcessName);
                }
            }
        }
    }
}
