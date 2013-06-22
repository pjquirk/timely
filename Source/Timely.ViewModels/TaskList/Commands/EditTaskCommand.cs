namespace Timely.ViewModels.TaskList.Commands
{
    public class EditTaskCommand : SelectedItemCommand, IEditTaskCommand
    {
        public EditTaskCommand(ITaskListViewModel taskListViewModel)
            : base(taskListViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            // TODO
        }
    }
}