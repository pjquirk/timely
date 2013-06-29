namespace Timely.ViewModels.EditTask
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IEditTimeBlockViewModel : IClosableViewModel, IDataErrorInfo
    {
        DateTime EndTime { get; set; }

        DateTime StartTime { get; set; }

        ICommand UpdateTimeBlockCommand { get; }
    }
}