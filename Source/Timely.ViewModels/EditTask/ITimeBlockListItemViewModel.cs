namespace Timely.ViewModels.EditTask
{
    using System;
    using Timely.ViewModels.Base;

    public interface ITimeBlockListItemViewModel : IViewModel
    {
        DateTime Date { get; }
        
        TimeSpan Time { get; }
    }
}