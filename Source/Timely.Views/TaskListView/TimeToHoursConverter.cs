namespace Timely.Views.TaskListView
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class TimeToHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan timeSpan = (TimeSpan)value;
            return string.Format("{0:F1}h", timeSpan.TotalHours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}