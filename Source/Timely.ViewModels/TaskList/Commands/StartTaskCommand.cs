namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.ViewModels.Common;

    public class StartTaskCommand : SelectedItemCommand, IStartTaskCommand
    {
        readonly IActiveTaskController activeTaskController;

        public StartTaskCommand(ITaskListViewModel taskListViewModel, IActiveTaskController activeTaskController)
            : base(taskListViewModel)
        {
            this.activeTaskController = activeTaskController;
        }

        public override void Execute(object parameter)
        {
            activeTaskController.Start(SelectedItem.Id);
        }

        public override bool CanExecute(object parameter)
        {
            // TODO: And not started
            return base.CanExecute(parameter);
        }
    }
}