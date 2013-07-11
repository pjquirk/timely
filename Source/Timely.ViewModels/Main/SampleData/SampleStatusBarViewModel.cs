namespace Timely.ViewModels.Main.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleStatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        public SampleStatusBarViewModel()
        {
            DayStartTime = DateTime.Now;
            IdleTime = TimeSpan.FromMinutes(35);
        }

        public DateTime DayStartTime { get; set; }
        
        public TimeSpan IdleTime { get; set; }
    }
}