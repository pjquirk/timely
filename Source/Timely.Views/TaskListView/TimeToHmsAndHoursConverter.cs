namespace Timely.Views.TaskListView
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class TimeToHmsAndHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan timeSpan = (TimeSpan)value;
            return string.Format("{0:00}:{1:00}:{2:00} ({3:F1}h)", 
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.TotalHours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}