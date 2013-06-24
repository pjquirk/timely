namespace Timely.Views.Base
{
    using System.Windows;
    using Timely.ViewModels.Base;

    public abstract class WindowBase : Window
    {
        protected WindowBase(IViewModel viewModel)
        {
            DataContext = viewModel;
            // Ghetto way to get CenterOwner to work...
            if (Application.Current.MainWindow != this)
                Owner = Application.Current.MainWindow;
        }
    }
}