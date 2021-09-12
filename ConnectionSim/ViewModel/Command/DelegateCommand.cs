using System;
using System.Windows.Input;

namespace ConnectionSim.ViewModel.Command
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T>  execute;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action<T> execute) : this(execute, () => true ) { }

        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this.execute     = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute();
        }

        public void Execute(object? parameter)
        {
            execute((T)parameter);
        }
        public event EventHandler? CanExecuteChanged;
    }
}