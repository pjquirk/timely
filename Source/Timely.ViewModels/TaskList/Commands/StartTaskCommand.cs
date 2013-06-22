namespace Timely.ViewModels.TaskList.Commands
{
    public class StartTaskCommand : SelectedItemCommand, IStartTaskCommand
    {
        public StartTaskCommand(ITaskListViewModel taskListViewModel)
            : base(taskListViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            // TODO
        }

        public override bool CanExecute(object parameter)
        {
            // TODO: And not started
            return base.CanExecute(parameter);
        }
    }
}