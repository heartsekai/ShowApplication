using System;
using System.Windows.Input;

namespace ShowApplication.ViewModels.Command
{
    internal class StartApplicationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object Window)
        {
            string processName = ((MainWindow)Window).SearchBox.Text;
            if (!string.IsNullOrEmpty(processName) || !string.IsNullOrWhiteSpace(processName))
            {
                StartProcess(processName);
            }
        }

        private void StartProcess(string processName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = processName;
            try
            {
                process.Start();
            }
            catch (Exception)
            {

                
            }
        }
    }
}