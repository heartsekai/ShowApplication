using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using CSWPFAutoCompleteTextBox;
using System.Linq;

namespace ShowApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        [DllImport("user32.dll",SetLastError = true,CharSet = CharSet.Auto)]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        List<Process> ProcessList;

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            // Get Only Processes with a Window attached.
            ProcessList = new List<Process>( Process.GetProcesses().Where(x => x.MainWindowHandle != IntPtr.Zero) );

            foreach (Process item in ProcessList)
            {
                if (!SearchBox.AutoSuggestionList.Contains(item.ProcessName))
                {
                    SearchBox.AutoSuggestionList.Add(item.ProcessName);
                }
            }
            
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var processByName = ProcessList.Find(x => x.ProcessName.ToLower().StartsWith(SearchBox.Text.ToLower()));

                if (processByName != null)
                {
                    var hWnd = processByName.MainWindowHandle;

                    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548(v=vs.85).aspx
                    // SW_SHOWMINIMIZED
                    //ShowWindowAsync(hWnd, 2);
                    // SW_RESTORE
                    //ShowWindowAsync(hWnd, 9);
                    // SW_SHOWNORMAL
                    //ShowWindowAsync(hWnd, 1);

                    // just in case we set it on the forground
                    SetForegroundWindow(hWnd);

                    Close();
                }
                else
                {
                    SearchBox.Text += " not Found.";
                }
                // TODO: if not process found start a new one
            }
            else if (SearchBox.Text.Contains("not Found") || e.Key == Key.Back)
            {
                SearchBox.Text = "";
            }
        }
    }


}
