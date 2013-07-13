namespace Timely.ViewModels.TaskList.Commands
{
    using System.Linq;
    using Timely.Models.Models;

    public class MoveDownTaskCommand : MoveTaskCommand, IMoveDownTaskCommand
    {
        public MoveDownTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel, tasksModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            if (SelectedItem != null)
            {
                int maxIndex = GetTasksInSelectedTaskGroup().Max(t => t.Index);
                return base.CanExecute(parameter) && SelectedItem.Index < maxIndex;
            }
            return base.CanExecute(parameter);
        }

        protected override void ExecuteInternal()
        {
            TasksModel.SetTaskIndex(SelectedItem.Id, SelectedItem.Index + 1);
        }
    }
}