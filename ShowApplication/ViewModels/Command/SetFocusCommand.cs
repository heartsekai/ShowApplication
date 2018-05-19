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

        public void Execute(object processName)
        {
            var process = Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero).ToList().Find(x => x.ProcessName.ToLower().StartsWith(((String)processName).ToLower()));
            if (process != null)
                WindowManager.RestoreWindow(process);
        }
    }
}
