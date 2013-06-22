namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.Models.Models;

    public class DeleteTaskCommand : SelectedItemCommand, IDeleteTaskCommand
    {
        readonly ITasksModel tasksModel;

        public DeleteTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel)
        {
            this.tasksModel = tasksModel;
        }

        public override void Execute(object parameter)
        {
            tasksModel.Delete(SelectedItem.Id);
        }
    }
}