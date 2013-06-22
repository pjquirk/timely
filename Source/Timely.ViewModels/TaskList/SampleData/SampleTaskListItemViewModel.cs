namespace Timely.ViewModels.TaskList.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleTaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        public string Header { get; set; }

        public Guid Id { get; private set; }

        public string TodayTime { get; set; }

        public string TotalTime { get; set; }
    }
}