namespace Timely.ViewModels.EditTask
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TimeBlockListItemViewModel : ViewModelBase, ITimeBlockListItemViewModel
    {
        readonly TimeBlock timeBlock;

        public TimeBlockListItemViewModel(TimeBlock timeBlock)
        {
            this.timeBlock = timeBlock;
        }

        public DateTime Date
        {
            get
            {
                return timeBlock.Start;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return timeBlock.End - timeBlock.Start;
            }
        }
    }
}