﻿using System;
using System.Windows.Input;

namespace PingViewer
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
                this.execute(parameter);
        }
    }
}
