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
            string timeString = string.Empty;

            if (timeSpan.TotalHours > 1)
            {
                timeString += string.Format("{0}:{1:00}", timeSpan.Hours, timeSpan.Minutes);
            }
            else if (timeSpan.TotalMinutes > 1)
            {
                timeString += string.Format("{0}", timeSpan.Minutes);
            }
            timeString += string.Format(":{0:00} ({1:F1}h)", timeSpan.Seconds, timeSpan.TotalHours);

            return timeString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}