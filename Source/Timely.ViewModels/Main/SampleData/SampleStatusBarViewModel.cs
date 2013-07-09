namespace Timely.ViewModels.Main.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleStatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        public SampleStatusBarViewModel()
        {
            DayStartTime = DateTime.Now;
        }

        public DateTime DayStartTime { get; set; }
    }
}