using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CoursierWallonBackOffice.Converter
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //No value provided
            if (value == null)
            {
                return null;
            }
            //No format provided
            if (parameter == null)
            {
                return null;
            }
            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
