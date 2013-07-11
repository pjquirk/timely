namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.Models.Models;

    public class MoveUpTaskCommand : MoveTaskCommand, IMoveUpTaskCommand
    {
        public MoveUpTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel, tasksModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && SelectedItem.Index > 0;
        }

        public override void Execute(object parameter)
        {
            TasksModel.SetTaskIndex(SelectedItem.Id, SelectedItem.Index - 1);
        }
    }
}