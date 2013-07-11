namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Windows.Input;
    using Timely.Models.Entities;
    using Timely.ViewModels.Base;

    public interface ITaskListItemViewModel : IViewModel
    {
        ICommand DeleteSelectedTaskCommand { get; }

        ICommand EditSelectedTaskCommand { get; }

        string Group { get; }
        
        string Header { get; }

        Guid Id { get; }

        int Index { get; }

        bool IsActive { get; set; }

        ICommand StartSelectedTaskCommand { get; }

        ICommand StopSelectedTaskCommand { get; }
        
        TimeSpan TodayTime { get; set; }

        TimeSpan TotalTime { get; set; }

        void Update(Task task);
    }
}