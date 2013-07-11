namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.Models.Models;

    public abstract class MoveTaskCommand : SelectedItemCommand
    {
        protected MoveTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel)
        {
            TasksModel = tasksModel;
        }

        protected ITasksModel TasksModel { get; private set; }
    }
}