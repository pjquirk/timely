namespace Timely.ViewModels.TaskList.Commands
{
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
                int minIndex = GetMinTaskIndexInGroup();
                return base.CanExecute(parameter) && SelectedItem.Index > minIndex;
            }
            return base.CanExecute(parameter);
        }

        protected override void ExecuteInternal()
        {
            int index = GetNextLowestIndexInGroup(SelectedItem.Index);
            TasksModel.SetTaskIndex(SelectedItem.Id, index);
        }

        int GetNextLowestIndexInGroup(int selectedIndex)
        {
            return GetTasksInSelectedTaskGroup().Where(t => t.Index < selectedIndex).Max(t => t.Index);
        }
    }
}