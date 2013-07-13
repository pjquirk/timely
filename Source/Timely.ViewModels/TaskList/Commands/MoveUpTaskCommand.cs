namespace Timely.ViewModels.TaskList.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Models;

    public class MoveUpTaskCommand : MoveTaskCommand, IMoveUpTaskCommand
    {
        public MoveUpTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel, tasksModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            if (SelectedItem != null)
            {
                int minIndex = GetTasksInSelectedTaskGroup().Min(t => t.Index);
                return base.CanExecute(parameter) && SelectedItem.Index > minIndex;
            }
            return base.CanExecute(parameter);
        }

        protected override void ExecuteInternal()
        {
            TasksModel.SetTaskIndex(SelectedItem.Id, SelectedItem.Index - 1);
        }
    }
}