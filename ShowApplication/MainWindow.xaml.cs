using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using ShowApplication.Model;

namespace ShowApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        private ViewModelBase viewModelBase;

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            viewModelBase = new ViewModelBase();
            this.DataContext = viewModelBase;
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                HideAndReset();
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var processByName = viewModelBase.GetProcessByNameWithWindow(SearchBox.Text);

                if (processByName != null)
                {
                    WindowManager.RestoreWindow(processByName);
                    HideAndReset();
                }
                else
                {
                    SearchBox.Text = "not Found";
                }
                // TODO: if not process found start a new one
            }
            else if (SearchBox.Text.Contains("not Found") || e.Key == Key.Back)
            {
                SearchBox.Text = "";
            }
        }

        private void HideAndReset()
        {
            // Empty Suggestions
            if (SearchBox.AutoSuggestionList.Count > 1)
            {
                SearchBox.AutoSuggestionList.Clear();
            }
            SearchBox.Text = "";
            Hide();
        }

        private void Applicaltion_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
