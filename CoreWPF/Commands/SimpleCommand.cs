using System;
using System.Windows.Input;

namespace CoreWPF.Commands
{
#pragma warning disable CC0031 // Check for null before calling a delegate
	public class SimpleCommand : ICommand
	{
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public virtual bool CanExecute(object parameter) => CanExecuteAction(parameter);

		public virtual void Execute(object parameter) => ExecuteAction(parameter);

		protected virtual Predicate<object> CanExecuteAction { get; }
		protected virtual Action<object> ExecuteAction { get; }

		public SimpleCommand(Action action) : this(_ => action?.Invoke())
		{
		}

		public SimpleCommand(Action action, Predicate<object> canExecute)
			: this(action == null ? (Action<object>)null : (_ => action()), canExecute)
		{
		}

		public SimpleCommand(Action<object> action) : this(action, null)
		{
		}

		public SimpleCommand(Action<object> action, Predicate<object> canExecute)
		{
			ExecuteAction = action ?? throw new ArgumentNullException("Action callback cannot be null", nameof(action));
			CanExecuteAction = canExecute ?? (_ => true);
		}
	}

	public class SimpleCommand<T> : ICommand
	{
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public virtual bool CanExecute(object parameter)
		{
			if (parameter is T t)
				return CanExecuteAction(t);

			return false;
		}

		public virtual void Execute(object parameter)
		{
			if (parameter is T t)
				ExecuteAction(t);
		}

		protected virtual Predicate<T> CanExecuteAction { get; }
		protected virtual Action<T> ExecuteAction { get; }

		public SimpleCommand(Action action) : this(_ => action?.Invoke())
		{
		}

		public SimpleCommand(Action action, Predicate<T> canExecute)
			: this(action == null ? (Action<T>)null : (_ => action()), canExecute)
		{
		}

		public SimpleCommand(Action<T> action) : this(action, null)
		{
		}

		public SimpleCommand(Action<T> action, Predicate<T> canExecute)
		{
			ExecuteAction = action ?? throw new ArgumentNullException("Action callback cannot be null", nameof(action));
			CanExecuteAction = canExecute ?? (_ => true);
		}
	}
#pragma warning restore CC0031 // Check for null before calling a delegate
}