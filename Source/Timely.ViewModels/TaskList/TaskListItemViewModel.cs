﻿namespace Timely.ViewModels.TaskList
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class TaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        readonly Task task;
        bool isActive;

        public TaskListItemViewModel(Task task)
        {
            this.task = task;
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

        public string TodayTime { get; private set; }

        public string TotalTime { get; private set; }
    }
}