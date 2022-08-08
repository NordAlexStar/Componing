using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyFirstWpfApp
{
    public class PeopleToStringConverter : IMultiValueConverter, IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            People? people = (People?)value;
            if (people == null) return null;
            return (people.Name ?? "") + " " + (people.Family ?? "");
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0]?.ToString() + " " + values[1]?.ToString();
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string) return null;

            string[] strings = ((string)value).Split(' ');

            if (strings.Length < 2)
            {
                return new People()
                {
                    Name = strings[0]
                };
            }
            else
            {
                return new People() { Name = strings[0], Family = strings[1] };
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] result = new string[2];

            if (value is string)
            {
                string[] strings = ((string)value).Split(' ');

                if (strings.Length < 2)
                {
                    result[0] = strings[0];
                }
                else
                {
                    result[0] = strings[0];
                    result[1] = strings[1];
                }
            }

            return result;
        }
    }
}
