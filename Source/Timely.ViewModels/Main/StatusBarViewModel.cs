namespace Timely.ViewModels.Main
{
    using System;
    using GalaSoft.MvvmLight;

    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        DateTime dayStartTime;

        public DateTime DayStartTime
        {
            get
            {
                return dayStartTime;
            }
            private set
            {
                dayStartTime = value;
                RaisePropertyChanged(() => dayStartTime);
            }
        }
    }
}