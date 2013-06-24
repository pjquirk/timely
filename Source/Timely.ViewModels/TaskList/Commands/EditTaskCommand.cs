namespace Timely.ViewModels.TaskList.Commands
{
    using Timely.ViewModels.Base;
    using Timely.ViewModels.EditTask;

    public class EditTaskCommand : SelectedItemCommand, IEditTaskCommand
    {
        readonly IViewFactory<IEditTaskView> editTaskViewFactory;
        readonly IEditTaskViewModelFactory editTaskViewModelFactory;

        public EditTaskCommand(
            ITaskListViewModel taskListViewModel,
            IViewFactory<IEditTaskView> editTaskViewFactory,
            IEditTaskViewModelFactory editTaskViewModelFactory)
            : base(taskListViewModel)
        {
            this.editTaskViewFactory = editTaskViewFactory;
            this.editTaskViewModelFactory = editTaskViewModelFactory;
        }

        public override void Execute(object parameter)
        {
            IEditTaskViewModel editTaskViewModel = editTaskViewModelFactory.Create(SelectedItem.Id);
            IEditTaskView editTaskView = editTaskViewFactory.Create(editTaskViewModel);
            editTaskView.ShowDialog();
        }
    }
}