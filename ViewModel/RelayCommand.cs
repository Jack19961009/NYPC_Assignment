using System;
using System.Diagnostics;
using System.Windows.Input;

namespace NYPC.ViewModel
{
    public class RelayCommand : ICommand
    {
        //Fields
        readonly Func<bool> _canExecute;
        readonly Action _execute;

        // Construstors
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }


        // ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
