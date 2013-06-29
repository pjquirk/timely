namespace Timely.ViewModels.EditTask
{
    using System;
    using Timely.Models.Entities;
    using Timely.ViewModels.Base;

    public interface ITimeBlockListItemViewModel : IViewModel
    {
        DateTime Date { get; }

        bool HideIfBeforeToday { get; set; }
        
        Guid Id { get; }
        
        bool IsVisible { get; }
        
        TimeSpan Time { get; }

        void Update(TimeBlock timeBlock);
    }
}