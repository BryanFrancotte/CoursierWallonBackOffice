using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CoursierWallonBackOffice.Converter
{
    class ParcelTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case 0:
                    return "S";
                case 1:
                    return "M";
                case 2:
                    return "L";
                case 3:
                    return "XL";
                default:
                    return "pas de type !";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
