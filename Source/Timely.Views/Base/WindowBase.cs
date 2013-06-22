namespace Timely.Views.Base
{
    using System.Windows;
    using Timely.ViewModels.Base;

    public abstract class WindowBase : Window
    {
        protected WindowBase(IViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}