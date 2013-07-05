namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        readonly ITaskListViewModel taskListViewModel;
        readonly ITodayTimeSummer todayTimeSummer;
        readonly ITotalTimeSummer totalTimeSummer;
        bool isActive;
        Task task;
        TimeSpan todayTime;
        TimeSpan totalTime;

        public TaskListItemViewModel(
            Task task,
            ITaskListViewModel taskListViewModel,
            ITotalTimeSummerFactory totalTimeSummerFactory,
            ITodayTimeSummerFactory todayTimeSummerFactory)
        {
            this.task = task;
            this.taskListViewModel = taskListViewModel;
            totalTimeSummer = totalTimeSummerFactory.Create(this);
            todayTimeSummer = todayTimeSummerFactory.Create(this);
            // Execute so the sums show up on the GUI immediately
            totalTimeSummer.Execute();
            todayTimeSummer.Execute();
        }

        public ICommand DeleteSelectedTaskCommand
        {
            get { return taskListViewModel.DeleteSelectedTaskCommand; }
        }

        public ICommand EditSelectedTaskCommand
        {
            get { return taskListViewModel.EditSelectedTaskCommand; }
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

        public ICommand StartSelectedTaskCommand
        {
            get { return taskListViewModel.StartSelectedTaskCommand; }
        }

        public ICommand StopSelectedTaskCommand
        {
            get { return taskListViewModel.StopSelectedTaskCommand; }
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