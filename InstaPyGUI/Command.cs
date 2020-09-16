using Apex.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstaPyGUI
{
    public class Command : ICommand
    {
        protected Action action = null;
        protected Action<object> parameterizedAction = null;
        private bool canExecute = false;

        public event EventHandler CanExecuteChanged;
        public event CancelCommandEventHandler Executing;
        public event CommandEventHandler Executed;
        public Command(Action action, bool canExecute = true)
        {
            //  Set the action.
            this.action = action;
            this.canExecute = canExecute;
        }
        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            //  Set the action.
            this.parameterizedAction = parameterizedAction;
            this.canExecute = canExecute;
        }
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                if (canExecute != value)
                {
                    canExecute = value;
                    EventHandler canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                        canExecuteChanged(this, EventArgs.Empty);
                }
            }
        }
        bool ICommand.CanExecute(object parameter)
        {
            return canExecute;
        }
        void ICommand.Execute(object parameter)
        {
            this.DoExecute(parameter);

        }
        protected void InvokeAction(object param)
        {
            Action theAction = action;
            Action<object> theParameterizedAction = parameterizedAction;
            if (theAction != null)
                theAction();
            else if (theParameterizedAction != null)
                theParameterizedAction(param);
        }
        protected void InvokeExecuted(CommandEventArgs args)
        {
            CommandEventHandler executed = Executed;

            //  Вызвать все события
            if (executed != null)
                executed(this, args);
        }
        protected void InvokeExecuting(CancelCommandEventArgs args)
        {
            CancelCommandEventHandler executing = Executing;

            //  Call the executed event.
            if (executing != null)
                executing(this, args);
        }
        public virtual void DoExecute(object param)
        {
            //  Вызывает выполнении команды с возможностью отмены
            CancelCommandEventArgs args =
               new CancelCommandEventArgs() { Parameter = param, Cancel = false };
            InvokeExecuting(args);

            //  Если событие было отменено -  останавливаем.
            if (args.Cancel)
                return;

            //  Вызываем действие с / без параметров, в зависимости от того. Какое было устанвленно.
            InvokeAction(param);

            //  Call the executed function.
            InvokeExecuted(new CommandEventArgs() { Parameter = param });
        }
    }
}
