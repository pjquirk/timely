namespace Timely.ViewModels.TaskList.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Models;

    public abstract class MoveTaskCommand : SelectedItemCommand
    {
        protected MoveTaskCommand(ITaskListViewModel taskListViewModel, ITasksModel tasksModel)
            : base(taskListViewModel)
        {
            TasksModel = tasksModel;
        }

        protected ITasksModel TasksModel { get; private set; }

        public override void Execute(object parameter)
        {
            ExecuteInternal();
            TaskListViewModel.RefreshIndices();
        }

        protected abstract void ExecuteInternal();

        protected int GetMaxTaskIndexInGroup()
        {
            return GetTasksInSelectedTaskGroup().Max(t => t.Index);
        }

        protected int GetMinTaskIndexInGroup()
        {
            return GetTasksInSelectedTaskGroup().Min(t => t.Index);
        }

        protected IEnumerable<ITaskListItemViewModel> GetTasksInSelectedTaskGroup()
        {
            return TaskListViewModel.Items.Where(t => t.GroupId == SelectedItem.GroupId);
        }
    }
}