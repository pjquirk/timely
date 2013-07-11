namespace Timely.Views.Main
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class StartTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime startTime = (DateTime)value;

            if (startTime != DateTime.MinValue)
                return "Day started at " + startTime.ToShortTimeString();
            return "Day has not started";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}