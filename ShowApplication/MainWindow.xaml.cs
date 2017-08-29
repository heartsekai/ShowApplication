using System;
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

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Process[] processByName = Process.GetProcessesByName(SearchBox.Text);

                if (processByName.Length > 0)
                {
                    IntPtr hWnd = IntPtr.Zero;
                    foreach (Process item in processByName)
                    {
                        if (item.MainWindowHandle != null)
                        {
                            hWnd = item.MainWindowHandle;
                        }
                    }

                    if (hWnd != null)
                    {
                        ShowWindowAsync(hWnd, 2);
                        ShowWindowAsync(hWnd, 1);

                        Close();
                    }
                }
            }
        }

    }


}
