﻿namespace Timely.ViewModels.TaskList
{
    using System;
    using Timely.Models.Entities;
    using Timely.ViewModels.Base;

    public interface ITaskListItemViewModel : IViewModel
    {
        string Header { get; }

        Guid Id { get; }
     
        bool IsActive { get; set; } 

        TimeSpan TodayTime { get; set;  }

        TimeSpan TotalTime { get; set;  }

        void Update(Task task);
    }
}