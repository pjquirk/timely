namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.Models.Common;
    using Timely.ViewModels.Common;

    public class StopTaskCommand : SelectedItemCommand, IStopTaskCommand
    {
        readonly IActiveTaskController activeTaskController;

        public StopTaskCommand(ITaskListViewModel taskListViewModel, IActiveTaskController activeTaskController)
            : base(taskListViewModel)
        {
            this.activeTaskController = activeTaskController;
            SubscribeToActiveTaskControllerEvents();
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && SelectedItem.Id == activeTaskController.ActiveTaskId;
        }

        public override void Execute(object parameter)
        {
            activeTaskController.Stop();
            OnCanExecuteChanged();
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