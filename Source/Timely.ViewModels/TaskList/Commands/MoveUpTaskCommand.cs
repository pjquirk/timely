namespace Timely.ViewModels.TaskList.Commands
{
    public class MoveUpTaskCommand : SelectedItemCommand, IMoveUpTaskCommand
    {
        public MoveUpTaskCommand(ITaskListViewModel taskListViewModel)
            : base(taskListViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}