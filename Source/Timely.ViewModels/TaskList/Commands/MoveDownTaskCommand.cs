namespace Timely.ViewModels.TaskList.Commands
{
    public class MoveDownTaskCommand : SelectedItemCommand, IMoveDownTaskCommand
    {
        public MoveDownTaskCommand(ITaskListViewModel taskListViewModel)
            : base(taskListViewModel)
        {
        }

        public override void Execute(object parameter)
        {
        }
    }
}