namespace Timely.ViewModels.EditTask.SampleData
{
    using System;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class SampleEditTimeBlockViewModel : ClosableViewModel, IEditTimeBlockViewModel
    {
        public SampleEditTimeBlockViewModel()
        {
            StartTime = DateTime.Today.AddHours(13);
            EndTime = DateTime.Today.AddHours(14.5);
        }

        public DateTime EndTime { get; set; }
        
        public string Error { get; private set; }

        public DateTime StartTime { get; set; }
        
        public ICommand UpdateTimeBlockCommand { get; private set; }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}