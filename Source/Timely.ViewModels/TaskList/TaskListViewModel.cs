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
    using Timely.ViewModels.Common;
    using Timely.ViewModels.TaskList.Commands;

    public class TaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        readonly IActiveTaskController activeTaskController;
        readonly ITimeBlockMediator timeBlockMediator;
        readonly ITaskListItemViewModelFactory taskListItemViewModelFactory;
        readonly ITasksModel tasksModel;
        ITaskListItemViewModel selectedItem;

        public TaskListViewModel(
            ITasksModel tasksModel,
            ITaskListItemViewModelFactory taskListItemViewModelFactory,
            IActiveTaskController activeTaskController,
            ITimeBlockMediatorFactory timeBlockMediatorFactory,
            ISelectedItemCommandFactory<IStartTaskCommand> startTaskCommandFactory,
            ISelectedItemCommandFactory<IStopTaskCommand> stopTaskCommandFactory,
            ISelectedItemCommandFactory<IEditTaskCommand> editTaskCommandFactory,
            ISelectedItemCommandFactory<IDeleteTaskCommand> deleteTaskCommandFactory)
        {
            this.tasksModel = tasksModel;
            this.taskListItemViewModelFactory = taskListItemViewModelFactory;
            this.activeTaskController = activeTaskController;
            this.timeBlockMediator = timeBlockMediatorFactory.Create(activeTaskController);
            DeleteSelectedTaskCommand = deleteTaskCommandFactory.Create(this);
            StartSelectedTaskCommand = startTaskCommandFactory.Create(this);
            StopSelectedTaskCommand = stopTaskCommandFactory.Create(this);
            EditSelectedTaskCommand = editTaskCommandFactory.Create(this);
            PopulateItems();
            SubscribeToTaskModelEvents();
            SubscribeToActiveTaskControllerEvents();
        }

        public event EventHandler SelectedItemChanged;

        public ICommand DeleteSelectedTaskCommand { get; private set; }

        public ICommand EditSelectedTaskCommand { get; private set; }

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

        public ICommand StartSelectedTaskCommand { get; private set; }

        public ICommand StopSelectedTaskCommand { get; private set; }

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

        void HandleActiveTaskIdChanged(object sender, EntityIdEventArgs e)
        {
            foreach (var item in Items)
                item.IsActive = (item.Id == e.Id);
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

        void SubscribeToActiveTaskControllerEvents()
        {
            activeTaskController.ActiveTaskIdChanged += HandleActiveTaskIdChanged;
        }

        void SubscribeToTaskModelEvents()
        {
            tasksModel.EntityAdded += HandleTaskAdded;
            tasksModel.EntityDeleted += HandleTaskDeleted;
        }
    }
}