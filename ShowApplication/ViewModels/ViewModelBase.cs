﻿using ShowApplication.ViewModels.Command;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    public class ViewModelBase
    {
        public ICommand TogleVisible { get; set; }
        public ICommand WakeUp { get; set; }
        public ICommand SetFocus { get; set; }
        public ICommand StartApplication { get; set; }
        private MainWindow MainWindow;

        public ViewModelBase()
        {
            this.MainWindow = Application.Current.MainWindow as MainWindow;
            TogleVisible = new TogleVisibilityCommand();
            WakeUp = new WakeUpCommand();
            SetFocus = new SetFocusCommand();
            StartApplication = new StartApplicationCommand();
        }
    }
}
