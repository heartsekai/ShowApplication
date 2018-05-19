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
            var processName = ((MainWindow)Window).SearchBox.Text;
            var selectedProcess = Process.GetProcesses()
                .Where(ProcessHasWindow())
                .ToList()
                .Find(First(processName));
            if (selectedProcess != null)
                WindowManager.RestoreWindow(selectedProcess);
        }

        private Func<Process,bool> ProcessHasWindow()
        {
            return process => process.MainWindowHandle != IntPtr.Zero;
        }

        private Predicate<Process> First(String processName)
        {
            return process => process.ProcessName.ToLower().StartsWith(processName.ToLower());
        }
    }
}
