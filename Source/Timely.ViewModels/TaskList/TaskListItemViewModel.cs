namespace Timely.ViewModels.TaskList
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        readonly ITodayTimeSummer todayTimeSummer;
        readonly ITotalTimeSummer totalTimeSummer;
        bool isActive;
        Task task;
        TimeSpan todayTime;
        TimeSpan totalTime;

        public TaskListItemViewModel(Task task, ITotalTimeSummerFactory totalTimeSummerFactory, ITodayTimeSummerFactory todayTimeSummerFactory)
        {
            this.task = task;
            totalTimeSummer = totalTimeSummerFactory.Create(this);
            todayTimeSummer = todayTimeSummerFactory.Create(this);
            // Execute so the sums show up on the GUI immediately
            totalTimeSummer.Execute();
            todayTimeSummer.Execute();
        }

        public string Header
        {
            get { return task.Description; }
        }

        public Guid Id
        {
            get { return task.Id; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                RaisePropertyChanged(() => IsActive);
            }
        }

        public TimeSpan TodayTime
        {
            get { return todayTime; }
            set
            {
                todayTime = value;
                RaisePropertyChanged(() => TodayTime);
            }
        }

        public TimeSpan TotalTime
        {
            get { return totalTime; }
            set
            {
                totalTime = value;
                RaisePropertyChanged(() => TotalTime);
            }
        }

        public void Update(Task task)
        {
            this.task = task;
            RaisePropertyChanged(() => Header);
            RaisePropertyChanged(() => Id);
            RaisePropertyChanged(() => TodayTime);
            RaisePropertyChanged(() => TotalTime);
        }
    }
}