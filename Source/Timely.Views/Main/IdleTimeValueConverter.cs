namespace Timely.Views.Main
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IdleTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan idleTime = (TimeSpan)value;

            if (idleTime > TimeSpan.Zero)
                return "Idle: " + idleTime;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}