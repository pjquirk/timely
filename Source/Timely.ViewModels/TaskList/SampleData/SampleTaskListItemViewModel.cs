namespace Timely.ViewModels.TaskList.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleTaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        public string Header { get; set; }

        public Guid Id { get; private set; }
        
        public bool IsActive { get; set; }

        public TimeSpan TodayTime { get; set; }

        public TimeSpan TotalTime { get; set; }
    }
}