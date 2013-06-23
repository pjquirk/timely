namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.Models.Common;
    using Timely.ViewModels.Common;

    public class StartTaskCommand : SelectedItemCommand, IStartTaskCommand
    {
        readonly IActiveTaskController activeTaskController;

        public StartTaskCommand(ITaskListViewModel taskListViewModel, IActiveTaskController activeTaskController)
            : base(taskListViewModel)
        {
            this.activeTaskController = activeTaskController;
            SubscribeToActiveTaskControllerEvents();
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && SelectedItem.Id != activeTaskController.ActiveTaskId;
        }

        public override void Execute(object parameter)
        {
            activeTaskController.Start(SelectedItem.Id);
        }

        void HandleTaskStartedOrStopped(object sender, EntityIdEventArgs e)
        {
            OnCanExecuteChanged();
        }

        void SubscribeToActiveTaskControllerEvents()
        {
            activeTaskController.TaskStarted += HandleTaskStartedOrStopped;
            activeTaskController.TaskStopped += HandleTaskStartedOrStopped;
        }
    }
}