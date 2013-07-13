namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class TaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        readonly IGroupsModel groupsModel;
        readonly ITaskListViewModel taskListViewModel;
        readonly ITodayTimeSummer todayTimeSummer;
        readonly ITotalTimeSummer totalTimeSummer;
        string group;
        bool isActive;
        Task task;
        TimeSpan todayTime;
        TimeSpan totalTime;

        public TaskListItemViewModel(
            Task task,
            ITaskListViewModel taskListViewModel,
            IGroupsModel groupsModel,
            ITotalTimeSummerFactory totalTimeSummerFactory,
            ITodayTimeSummerFactory todayTimeSummerFactory)
        {
            this.taskListViewModel = taskListViewModel;
            this.groupsModel = groupsModel;
            Update(task);
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

        public string Group
        {
            get { return group; }
            private set
            {
                if (group != value)
                {
                    group = value;
                    RaisePropertyChanged(() => Group);
                }
            }
        }

        public Guid GroupId
        {
            get { return task.GroupId; }
        }

        public string Header
        {
            get { return task.Description; }
        }

        public Guid Id
        {
            get { return task.Id; }
        }

        public int Index
        {
            get { return task.Index; }
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
            RaisePropertyChanged(() => Index);
            RaisePropertyChanged(() => TodayTime);
            RaisePropertyChanged(() => TotalTime);
            Group = groupsModel.GetGroupName(task.GroupId);
        }
    }
}