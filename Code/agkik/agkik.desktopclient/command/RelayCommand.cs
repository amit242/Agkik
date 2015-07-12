using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace agkik.desktopclient.Command
{
    class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _action;
        private readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        public RelayCommand(Action<object> action) : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "Action<T> not specified");
            }
            _action = action;
            _canExecute = canExecute;
        }
        #endregion // Constructors


        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }
        #endregion // ICommand Members
    }
}
