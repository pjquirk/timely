namespace Timely.Views.TaskListView
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ActiveTaskIndicatorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isActive = (bool)value;
            return (isActive) ? ">" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}