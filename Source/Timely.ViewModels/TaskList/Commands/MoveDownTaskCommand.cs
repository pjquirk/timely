namespace Timely.ViewModels.TaskList.Commands
{
    using System;
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
                int maxIndex = GetMaxTaskIndexInGroup();
                return base.CanExecute(parameter) && SelectedItem.Index < maxIndex;
            }
            return base.CanExecute(parameter);
        }

        protected override void ExecuteInternal()
        {
            int index = GetNextHighestIndexInGroup(SelectedItem.Index);
            TasksModel.SetTaskIndex(SelectedItem.Id, index);
        }

        int GetNextHighestIndexInGroup(int selectedIndex)
        {
            return GetTasksInSelectedTaskGroup().Where(t => t.Index > selectedIndex).Min(t => t.Index);
        }
    }
}