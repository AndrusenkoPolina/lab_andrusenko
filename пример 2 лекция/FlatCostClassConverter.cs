using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace пример_2_лекция
{
    public class FlatCostClassConverter : IMultiValueConverter
    {
        private const int COST=1000;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cost = (int)values[0];
            var area = (int)values[1];

            var materCost = cost / area;
            if (materCost > COST)
            {
                return "Дорогая";
            }

            else
            { return "Дешёвая"; }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
