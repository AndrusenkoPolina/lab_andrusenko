using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace пример_2_лекция
{
    public class MetroStationColorConverter : IValueConverter
    {
        //метод из строки в цвет
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var metroName = value as string;
                if (String.IsNullOrWhiteSpace(metroName))
                    return Colors.White;



                switch (metroName)
                {
                    case "Академическая":
                    case "Шаболовская":
                    case "Китай-город":
                        {
                            return new SolidColorBrush(Colors.Orange);

                        }
                    case "Новокузнецкая":
                    case "Театральная":
                        {
                            return new SolidColorBrush(Colors.Green);

                        }
                    default:
                        {
                            return new SolidColorBrush(Colors.White);
                        }
                }
            }
            
           catch
            {
                return Colors.White;
            }
        }


    // Мето из цвета в строку, ам не понадобится в данной задачи поэтому возвращаем это. Не null, чтобы не запутаться
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
