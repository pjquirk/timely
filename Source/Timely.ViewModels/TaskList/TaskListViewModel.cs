namespace Timely.ViewModels.TaskList
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using GalaSoft.MvvmLight;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class TaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        readonly ITaskListItemViewModelFactory taskListItemViewModelFactory;
        readonly ITasksModel tasksModel;

        public TaskListViewModel(ITasksModel tasksModel, ITaskListItemViewModelFactory taskListItemViewModelFactory)
        {
            this.tasksModel = tasksModel;
            this.taskListItemViewModelFactory = taskListItemViewModelFactory;
            PopulateItems();
            SubscribeToTaskAdded();
        }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }

        public ITaskListItemViewModel SelectedItem { get; set; }

        ITaskListItemViewModel CreateItemViewModel(Task task)
        {
            return taskListItemViewModelFactory.Create(task);
        }

        void HandleTaskAdded(object sender, EntityEventArgs<Task> e)
        {
            Items.Add(CreateItemViewModel(e.Entity));
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>(tasksModel.GetAll().Select(CreateItemViewModel));
        }

        void SubscribeToTaskAdded()
        {
            tasksModel.EntityAdded += HandleTaskAdded;
        }
    }
}