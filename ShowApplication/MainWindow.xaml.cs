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
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

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
                Process[] processByName = ProcessList.FindAll(x => x.ProcessName.ToLower().StartsWith(SearchBox.Text.ToLower())).ToArray();

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
                        ShowWindowAsync(hWnd, 2);
                        ShowWindowAsync(hWnd, 1);

                        Close();
                    }
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
