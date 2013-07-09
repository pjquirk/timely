namespace Timely.Views.Main
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Timely.Views.TaskListView;

    public class IdleTimeValueConverter : IValueConverter
    {
        TimeToHmsAndHoursConverter hmsConverter = new TimeToHmsAndHoursConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan idleTime = (TimeSpan)value;

            if (idleTime > TimeSpan.Zero)
                return "Idle: " + hmsConverter.Convert(idleTime, typeof(string), null, culture);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}