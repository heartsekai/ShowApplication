using System;
using System.Windows;
using System.Windows.Input;

namespace ShowApplication
{
    public class TogleVisibleCommand : ICommand
    {
        public TogleVisibleCommand(ViewModelBase viewModelBase)
        {
            this.ViewModelBase = viewModelBase;
        }

        public ViewModelBase ViewModelBase { get; }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModelBase.TogleVisibility();
        }
    }
}
