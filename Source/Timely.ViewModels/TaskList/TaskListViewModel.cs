namespace Timely.ViewModels.TaskList
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using GalaSoft.MvvmLight;
    using Timely.Models.Models;

    public class TaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        readonly ITasksModel tasksModel;
        readonly ITaskListItemViewModelFactory taskListItemViewModelFactory;

        public TaskListViewModel(ITasksModel tasksModel, ITaskListItemViewModelFactory taskListItemViewModelFactory)
        {
            this.tasksModel = tasksModel;
            this.taskListItemViewModelFactory = taskListItemViewModelFactory;
            PopulateItems();
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>(tasksModel.GetAll().Select(t => taskListItemViewModelFactory.Create(t)));
        }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }

        public ITaskListItemViewModel SelectedItem { get; set; }
    }
}