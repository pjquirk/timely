namespace Timely.ViewModels.TaskList.Commands
{
    public class StopTaskCommand : SelectedItemCommand, IStopTaskCommand
    {
        public StopTaskCommand(ITaskListViewModel taskListViewModel)
            : base(taskListViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            // TODO
        }

        public override bool CanExecute(object parameter)
        {
            // TODO: And not stopped
            return base.CanExecute(parameter);
        }
    }
}