using System;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    public class ViewModelBase
    {
        public ICommand TogleVisible { get; set; }

        public ViewModelBase()
        {
            TogleVisible = new TogleVisibleCommand(this);
        }

        internal void TogleVisibility()
        {
            if (Application.Current.MainWindow.IsVisible)
            {
                Application.Current.MainWindow.Hide();
            }
            else
            {
                Application.Current.MainWindow.Show();
            }
        }
    }
}