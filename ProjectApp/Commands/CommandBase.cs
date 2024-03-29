﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectApp.Commands
{
    class CommandBase : ICommand
    {
        private Action<object> execute;// определяет, может ли команда выполняться
        private Func<object, bool> canExecute;
 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
 
        public CommandBase(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
 
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
 
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
