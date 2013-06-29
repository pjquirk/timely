namespace Timely.ViewModels.EditTask.SampleData
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class SampleTimeBlockListItemViewModel : ViewModelBase, ITimeBlockListItemViewModel
    {
        public DateTime Date { get; set; }

        public Guid Id { get; private set; }

        public TimeSpan Time { get; set; }

        public void Update(TimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }
    }
}