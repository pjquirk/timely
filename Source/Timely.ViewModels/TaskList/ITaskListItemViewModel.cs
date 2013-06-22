namespace Timely.ViewModels.TaskList
{
    using System;
    using Timely.ViewModels.Base;

    public interface ITaskListItemViewModel : IViewModel
    {
        string Header { get; }
    
        Guid Id { get; }

        string TodayTime { get; }

        string TotalTime { get; }
    }
}