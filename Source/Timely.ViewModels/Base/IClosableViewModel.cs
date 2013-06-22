namespace Timely.ViewModels.Base
{
    public interface IClosableViewModel : IViewModel
    {
        bool? DialogResult { get; }

        void Cancel();

        void Close();
    }
}