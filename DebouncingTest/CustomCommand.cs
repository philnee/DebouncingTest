using System;
using System.Windows.Input;

namespace DebouncingTest
{
    public class CustomCommand : ICommand
    {
        public delegate void CommandOnExecute();
        public delegate bool CommandOnCanExecute(object parameter);

        private readonly CommandOnExecute _execute;
        private readonly CommandOnCanExecute _canExecute;

        public CustomCommand(CommandOnExecute onExecuteMethod, CommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        public CustomCommand(CommandOnExecute onExecuteMethod) : this(onExecuteMethod, (obj) => true)
        {
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        #endregion
    }
}