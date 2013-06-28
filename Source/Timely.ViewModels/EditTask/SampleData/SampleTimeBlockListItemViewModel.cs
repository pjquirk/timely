namespace Timely.ViewModels.EditTask.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleTimeBlockListItemViewModel : ViewModelBase, ITimeBlockListItemViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}