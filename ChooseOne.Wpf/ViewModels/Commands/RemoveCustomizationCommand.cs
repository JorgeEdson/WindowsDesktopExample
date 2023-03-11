using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChooseOne.Wpf.ViewModels.Commands
{
    public class RemoveCustomizationCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action _execute;

        public RemoveCustomizationCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke();
        }
    }
}
