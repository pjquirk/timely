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
            int maxIndex = TaskListViewModel.Items.Max(t => t.Index);
            return base.CanExecute(parameter) && SelectedItem.Index < maxIndex;
        }

        public override void Execute(object parameter)
        {
            TasksModel.SetTaskIndex(SelectedItem.Id, SelectedItem.Index + 1);
        }
    }
}