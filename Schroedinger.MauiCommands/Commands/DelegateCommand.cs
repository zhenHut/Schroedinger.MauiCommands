using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schroedinger.MauiCommands.Commands
{
    public class DelegateCommand<T> : ICommand
    {
        #region Construktor
        public DelegateCommand(Action<T>? execute, Predicate<T>? canExexute = null)
        {
            this.canExecute = canExexute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }
        #endregion

        #region Property

        Predicate<T>? canExecute { get; set; }
        Action<T>? execute { get; set; }

        #endregion

        #region Events
        public event EventHandler? CanExecuteChanged;

        #endregion


        #region Methods

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || parameter is T param && canExecute((T)param) == true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T param)
                execute?.Invoke(param);
        }
        #endregion
    }
}
