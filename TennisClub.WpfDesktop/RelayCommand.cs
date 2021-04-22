using System;
using System.Windows.Input;

namespace TennisClub.WpfDesktop
{
    class RelayCommand<T> : ICommand 
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            if (parameter != null) return _canExecute.Invoke((T) parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke((T) parameter);
        }
    }
}