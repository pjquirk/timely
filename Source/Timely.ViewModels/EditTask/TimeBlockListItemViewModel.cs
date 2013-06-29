namespace Timely.ViewModels.EditTask
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TimeBlockListItemViewModel : ViewModelBase, ITimeBlockListItemViewModel
    {
        TimeBlock timeBlock;

        public TimeBlockListItemViewModel(TimeBlock timeBlock)
        {
            this.timeBlock = timeBlock;
        }

        public DateTime Date
        {
            get { return timeBlock.Start.ToLocalTime(); }
        }

        public Guid Id
        {
            get { return timeBlock.Id; }
        }

        public TimeSpan Time
        {
            get { return timeBlock.End - timeBlock.Start; }
        }

        public void Update(TimeBlock timeBlock)
        {
            this.timeBlock = timeBlock;
            RaisePropertyChanged(() => Date);
            RaisePropertyChanged(() => Time);
        }
    }
}