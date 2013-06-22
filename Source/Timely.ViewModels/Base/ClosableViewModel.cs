namespace Timely.ViewModels.Base
{
    using GalaSoft.MvvmLight;

    public abstract class ClosableViewModel : ViewModelBase, IClosableViewModel
    {
        bool? dialogResult;
        public bool? DialogResult
        {
            get { return dialogResult; }
            private set
            {
                dialogResult = value;
                RaisePropertyChanged(() => DialogResult);
            }
        }

        public void Cancel()
        {
            DialogResult = false;
        }

        public void Close()
        {
            DialogResult = true;
        }
    }
}