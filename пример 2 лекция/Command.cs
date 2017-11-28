using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace пример_2_лекция
{
    public class Command: ICommand
    {
        public bool CanExecute(object paramenter)
        { return true; }

        public void Execute(object parameter)

        {
            var methFlats = parameter.GetType().GetMethod("FillFlats", BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.InvokeMethod);
            if (methFlats != null)
            {
                object[] parameters = null;
                methFlats.Invoke(parameter, parameters);
            }

            var vnfilter = parameter as MainWindowsVewModel;
            if (vnfilter == null)
            {
                throw new ArgumentNullException("Модель представления не может быть null");
            }
            if (String.IsNullOrWhiteSpace(vnfilter.selectedMetro.Key))
            {
                throw new ArgumentNullException("Выберите название метро");
            }

            var flats = vnfilter.flats.Where(
                x => x.area >= vnfilter.Areamin && x.area <= vnfilter.Areamax &&
                x.price >= vnfilter.Pricemin && x.price <= vnfilter.Pricemax &&
                x.metro.Equals(vnfilter.selectedMetro.Key, StringComparison.CurrentCultureIgnoreCase)
                );

            ObservableCollection<FlatViewModel> newElements = new ObservableCollection<FlatViewModel>();

            foreach (var f in flats)
            {
                newElements.Add(f);
            }

            var prop = parameter.GetType().GetProperty("flats", BindingFlags.GetProperty |
                BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(parameter, newElements);

            var meth = parameter.GetType().GetMethod("DoPropertyChanged");
            if (meth != null)
            {
                object[] parameters = new object[] { "flats" };
                meth.Invoke(parameter, parameters);
            }
                
        }

        public event EventHandler CanExecuteChanged;
    }
}
