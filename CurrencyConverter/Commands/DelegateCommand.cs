using System;
using System.Windows.Input;

namespace CurrencyConverter.Commands
{
    /// <summary>
    /// DelegateCommand for handling the events
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Delegates
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// Constructor
        /// </summary>
        /// <param name="action">Action</param>
        public DelegateCommand(Action<object> action)
            : this(action, null)
        {
            this.execute = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// Constructor
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="predicate">Predicate</param>
        private DelegateCommand(Action<object> action, Predicate<object> predicate)
        {
            this.execute = action;
            this.canExecute = predicate;
        }
        #endregion

        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Commands

        /// <summary>
        /// Can Command Execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        #endregion

        #region EventHandler

        /// <summary>
        /// Raised Can Execute Changed Handler
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
