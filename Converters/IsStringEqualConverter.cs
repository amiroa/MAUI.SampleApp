using System.Globalization;

namespace OA.Public.Maui.SampleApp.Converters
{
    class IsStringEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.ToString() == parameter.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
