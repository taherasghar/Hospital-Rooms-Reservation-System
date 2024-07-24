using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanExcute { get; set; }

        public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExcuteMethod)
        {

            _Execute = ExecuteMethod;
            _CanExcute = CanExcuteMethod;

        }

        public bool CanExecute(object? parameter)
        {
            return _CanExcute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
