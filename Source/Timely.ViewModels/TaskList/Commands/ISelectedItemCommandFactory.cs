namespace Timely.ViewModels.TaskList.Commands
{
    public interface ISelectedItemCommandFactory<T> where T : ISelectedItemCommand
    {
        T Create(ITaskListViewModel taskListViewModel);
    }
}