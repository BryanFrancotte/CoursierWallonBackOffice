using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CoursierWallonBackOffice.Converter
{
    class DeliveryTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case 0:
                    return "Normal";
                case 1:
                    return "Semi-express";
                case 2:
                    return "Express";
                default:
                    return "pas de type de livraison";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
