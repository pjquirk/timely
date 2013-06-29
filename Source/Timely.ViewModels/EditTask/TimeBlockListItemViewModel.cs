namespace Timely.ViewModels.EditTask
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TimeBlockListItemViewModel : ViewModelBase, ITimeBlockListItemViewModel
    {
        bool hideIfBeforeToday;
        bool isVisible;
        TimeBlock timeBlock;

        public TimeBlockListItemViewModel(TimeBlock timeBlock)
        {
            this.timeBlock = timeBlock;
        }

        public DateTime Date
        {
            get { return timeBlock.Start.ToLocalTime(); }
        }

        public bool HideIfBeforeToday
        {
            get { return hideIfBeforeToday; }
            set
            {
                hideIfBeforeToday = value;
                IsVisible = !hideIfBeforeToday || Date.Date == DateTime.Today;
            }
        }

        public Guid Id
        {
            get { return timeBlock.Id; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            private set
            {
                isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
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