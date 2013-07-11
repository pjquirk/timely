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

        public override void Execute(object parameter)
        {
            ExecuteInternal();
            TaskListViewModel.RefreshIndices();
        }

        protected abstract void ExecuteInternal();

        protected ITasksModel TasksModel { get; private set; }
    }
}