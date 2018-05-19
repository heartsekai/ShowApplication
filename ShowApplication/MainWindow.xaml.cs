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

            this.PreviewKeyDown += new KeyEventHandler(KeyHandler);

            viewModelBase = new ViewModelBase();
            this.DataContext = viewModelBase;
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && viewModelBase.TogleVisible.CanExecute(null))
                viewModelBase.TogleVisible.Execute(this);
            else if (e.Key == Key.Enter && viewModelBase.SetFocus.CanExecute(null))
            {
                viewModelBase.SetFocus.Execute(SearchBox.Text);

                if (viewModelBase.TogleVisible.CanExecute(null))
                    viewModelBase.TogleVisible.Execute(this);
            }
        }

        private void Applicaltion_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
