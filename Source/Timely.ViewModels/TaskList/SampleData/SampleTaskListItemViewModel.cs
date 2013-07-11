namespace Timely.ViewModels.TaskList.SampleData
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class SampleTaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        public ICommand DeleteSelectedTaskCommand { get; private set; }
        
        public ICommand EditSelectedTaskCommand { get; private set; }
        
        public string Group { get; private set; }

        public string Header { get; set; }

        public Guid Id { get; private set; }
        
        public int Index { get; private set; }

        public bool IsActive { get; set; }
        
        public ICommand StartSelectedTaskCommand { get; private set; }
        
        public ICommand StopSelectedTaskCommand { get; private set; }

        public TimeSpan TodayTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}