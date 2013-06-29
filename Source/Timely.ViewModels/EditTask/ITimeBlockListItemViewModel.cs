namespace Timely.ViewModels.EditTask
{
    using System;
    using Timely.Models.Entities;
    using Timely.ViewModels.Base;

    public interface ITimeBlockListItemViewModel : IViewModel
    {
        DateTime Date { get; }

        Guid Id { get; }

        TimeSpan Time { get; }

        void Update(TimeBlock timeBlock);
    }
}