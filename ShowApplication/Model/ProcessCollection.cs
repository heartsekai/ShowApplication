using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowApplication.Model
{
    class ProcessCollection
    {
        private List<Process> ProcessList;

        public ProcessCollection()
        {
            RefreshProcessList();
        }

        public void RefreshProcessList()
        {
            ProcessList = new List<Process>(Process.GetProcesses());
        }

        public List<Process> GetProcessesWithWindow()
        {
            return ProcessList.Where(x => x.MainWindowHandle != IntPtr.Zero).ToList();
        }

        public Process GetProcessByName(String processName)
        {
            return ProcessList.Find(x => x.ProcessName.ToLower().StartsWith(processName.ToLower()));
        }
    }
}
