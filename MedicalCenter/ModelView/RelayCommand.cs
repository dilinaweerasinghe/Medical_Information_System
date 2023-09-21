using System.Windows.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MedicalCenter.ModelView
{
    public class RelayCommand : ICommand
    {
       

        public event EventHandler CanExecuteChanged;
        public Action<object> _Execute{ get; set; }
        public Predicate<object> _CanExecute { get; set; }

        public RelayCommand(Action<object> execute, Predicate<object> predicate)
        {
            _Execute = execute;
            _CanExecute = predicate;
        }

        public bool CanExecute(object parameter)
        {

            return _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
