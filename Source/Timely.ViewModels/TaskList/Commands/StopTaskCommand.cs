namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.ViewModels.Common;

    public class StopTaskCommand : SelectedItemCommand, IStopTaskCommand
    {
        readonly IActiveTaskController activeTaskController;

        public StopTaskCommand(ITaskListViewModel taskListViewModel, IActiveTaskController activeTaskController)
            : base(taskListViewModel)
        {
            this.activeTaskController = activeTaskController;
        }

        public override void Execute(object parameter)
        {
            activeTaskController.Stop();
        }

        public override bool CanExecute(object parameter)
        {
            // TODO: And not stopped
            return base.CanExecute(parameter);
        }
    }
}