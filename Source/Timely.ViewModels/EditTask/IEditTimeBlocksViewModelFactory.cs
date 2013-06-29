namespace Timely.ViewModels.EditTask
{
    using System;

    public interface IEditTimeBlocksViewModelFactory
    {
        IEditTimeBlocksViewModel Create(Guid taskId);
    }
}