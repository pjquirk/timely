namespace Timely.ViewModels.TaskList.Commands
{
    using System;
    using Timely.ViewModels.Base;

    public abstract class SelectedItemCommand : CommandBase, ISelectedItemCommand
    {
        protected SelectedItemCommand(ITaskListViewModel taskListViewModel)
        {
            TaskListViewModel = taskListViewModel;
            TaskListViewModel.SelectedItemChanged += HandleSelectedItemChanged;
        }

        protected ITaskListItemViewModel SelectedItem
        {
            get { return TaskListViewModel.SelectedItem; }
        }

        protected ITaskListViewModel TaskListViewModel { get; private set; }

        public override bool CanExecute(object parameter)
        {
            return SelectedItem != null;
        }

        void HandleSelectedItemChanged(object sender, EventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}