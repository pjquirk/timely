namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.TaskList.Commands;

    public class TaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        readonly ITaskListItemViewModelFactory taskListItemViewModelFactory;
        readonly ITasksModel tasksModel;
        ITaskListItemViewModel selectedItem;

        public TaskListViewModel(ITasksModel tasksModel, ITaskListItemViewModelFactory taskListItemViewModelFactory, ISelectedItemCommandFactory<IDeleteTaskCommand> deleteTaskCommandFactory)
        {
            this.tasksModel = tasksModel;
            this.taskListItemViewModelFactory = taskListItemViewModelFactory;
            DeleteSelectedTaskCommand = deleteTaskCommandFactory.Create(this);
            PopulateItems();
            SubscribeToTaskModelEvents();
        }

        public event EventHandler SelectedItemChanged;

        public ICommand DeleteSelectedTaskCommand { get; private set; }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }

        public ITaskListItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
                OnSelectedItemChanged();
            }
        }

        protected virtual void OnSelectedItemChanged()
        {
            EventHandler handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        ITaskListItemViewModel CreateItemViewModel(Task task)
        {
            return taskListItemViewModelFactory.Create(task);
        }

        void HandleTaskAdded(object sender, EntityEventArgs<Task> e)
        {
            Items.Add(CreateItemViewModel(e.Entity));
        }

        void HandleTaskDeleted(object sender, EntityIdEventArgs e)
        {
            ITaskListItemViewModel item = Items.FirstOrDefault(i => i.Id == e.Id);
            if (item != null)
                Items.Remove(item);
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>(tasksModel.GetAll().Select(CreateItemViewModel));
        }

        void SubscribeToTaskModelEvents()
        {
            tasksModel.EntityAdded += HandleTaskAdded;
            tasksModel.EntityDeleted += HandleTaskDeleted;
        }
    }
}