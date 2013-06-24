namespace Timely.ViewModels.EditTask
{
    using System;

    public interface IEditTaskViewModelFactory
    {
        IEditTaskViewModel Create(Guid taskId);
    }
}