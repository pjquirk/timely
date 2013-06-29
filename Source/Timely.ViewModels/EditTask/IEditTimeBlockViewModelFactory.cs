namespace Timely.ViewModels.EditTask
{
    using System;

    public interface IEditTimeBlockViewModelFactory
    {
        IEditTimeBlockViewModel Create(Guid timeBlockId);
    }
}