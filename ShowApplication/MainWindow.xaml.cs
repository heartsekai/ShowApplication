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
            if (e.Key == Key.Escape && viewModelBase.TogleVisible.CanExecute(null))
                viewModelBase.TogleVisible.Execute(null);
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && viewModelBase.SetFocus.CanExecute(null))
            {
                viewModelBase.SetFocus.Execute(SearchBox.Text);

                if (viewModelBase.TogleVisible.CanExecute(null))
                    viewModelBase.TogleVisible.Execute(null);
            }
        }

        private void Applicaltion_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
