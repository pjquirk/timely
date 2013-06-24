namespace Timely.ViewModels.TaskList.SampleData
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class SampleTaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        public string Header { get; set; }

        public Guid Id { get; private set; }

        public bool IsActive { get; set; }

        public TimeSpan TodayTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}