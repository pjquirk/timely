namespace Timely.ViewModels.TaskList
{
    using Timely.Models.Entities;

    public interface ITaskListItemViewModelFactory
    {
        ITaskListItemViewModel Create(Task task, ITaskListViewModel taskListViewModel);
    }
}