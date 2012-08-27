using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Cargowire.Commands
{
    public class RelayCommand<T> : ICommand
    {
        readonly Predicate<T> _canExecute;
        readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {

            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			EventHandler handler = this.CanExecuteChanged;
			if (handler != null)
			{
				handler(this, new EventArgs());
			}
		}

        [DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(Object parameter)
        {
            _execute((T)parameter);
        }
    }
}
