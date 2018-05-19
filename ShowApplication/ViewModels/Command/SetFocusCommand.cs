using ShowApplication.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace ShowApplication.ViewModels.Command
{
    class SetFocusCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object Window)
        {
            var mainWindow = (MainWindow)Window;
            var selectedProcess = Process.GetProcesses()
                .Where(process => process.MainWindowHandle != IntPtr.Zero)
                .ToList()
                .Find(name => name.ProcessName.ToLower().StartsWith(mainWindow.SearchBox.Text.ToLower()));
            if (selectedProcess != null)
                WindowManager.RestoreWindow(selectedProcess);
        }
    }
}
