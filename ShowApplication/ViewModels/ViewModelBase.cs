using ShowApplication.Model;
using ShowApplication.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    public class ViewModelBase
    {
        public ICommand TogleVisible { get; set; }
        public ICommand WakeUp { get; set; }
        private MainWindow MainWindow;

        public ViewModelBase()
        {
            this.MainWindow = Application.Current.MainWindow as MainWindow;
            TogleVisible = new TogleVisibilityCommand(this.MainWindow);
            WakeUp = new WakeUpCommand(this.MainWindow);
        }

        public Process GetProcessByNameWithWindow(String processName)
        {
            return Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero).ToList().Find(x => x.ProcessName.ToLower().StartsWith(processName.ToLower()));
        }

        public List<Process> GetProcessesWithWindow()
        {
            return Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero).ToList();
        }
    }
}