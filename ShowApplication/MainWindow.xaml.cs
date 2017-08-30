using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        List<Process> ProcessList;

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            ProcessList = new List<Process>( Process.GetProcesses() );
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
                Process[] processByName = ProcessList.FindAll(x => x.ProcessName.ToLower().Contains(SearchBox.Text.ToLower())).ToArray();

                if (processByName.Length > 0)
                {
                    IntPtr hWnd = IntPtr.Zero;
                    foreach (Process item in processByName)
                    {
                        if (item.MainWindowHandle != IntPtr.Zero)
                        {
                            hWnd = item.MainWindowHandle;
                        }
                    }

                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindowAsync(hWnd, 10);
                        ShowWindowAsync(hWnd, 1);

                        Close();
                    }
                }
                else
                {
                    SearchBox.AppendText(" not Found.");
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
