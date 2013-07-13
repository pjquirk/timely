namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Data;
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
        readonly ITaskListItemViewModelFactory taskListItemViewModelFactory;
        readonly ITasksModel tasksModel;
        ITaskListItemViewModel selectedItem;
        ITimeBlockMediator timeBlockMediator;

        public TaskListViewModel(
            ITasksModel tasksModel,
            ITaskListItemViewModelFactory taskListItemViewModelFactory,
            IActiveTaskController activeTaskController,
            ITimeBlockMediatorFactory timeBlockMediatorFactory,
            ISelectedItemCommandFactory<IStartTaskCommand> startTaskCommandFactory,
            ISelectedItemCommandFactory<IStopTaskCommand> stopTaskCommandFactory,
            ISelectedItemCommandFactory<IEditTaskCommand> editTaskCommandFactory,
            ISelectedItemCommandFactory<IMoveUpTaskCommand> moveUpTaskCommandFactory,
            ISelectedItemCommandFactory<IMoveDownTaskCommand> moveDownTaskCommandFactory,
            ISelectedItemCommandFactory<IDeleteTaskCommand> deleteTaskCommandFactory)
        {
            this.tasksModel = tasksModel;
            this.taskListItemViewModelFactory = taskListItemViewModelFactory;
            this.activeTaskController = activeTaskController;
            timeBlockMediator = timeBlockMediatorFactory.Create(activeTaskController);
            CreateCommands(
                startTaskCommandFactory,
                stopTaskCommandFactory,
                editTaskCommandFactory,
                moveUpTaskCommandFactory,
                moveDownTaskCommandFactory,
                deleteTaskCommandFactory);
            PopulateItems();
            SubscribeToTaskModelEvents();
            SubscribeToActiveTaskControllerEvents();
        }

        public event EventHandler SelectedItemChanged;

        public ICommand DeleteSelectedTaskCommand { get; private set; }

        public ICommand EditSelectedTaskCommand { get; private set; }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }

        public ICollectionView ItemsView { get; private set; }

        public ICommand MoveDownSelectedTaskCommand { get; private set; }

        public ICommand MoveUpSelectedTaskCommand { get; private set; }

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

        public void RefreshIndices()
        {
            foreach (var item in Items)
                item.Update(tasksModel.Get(item.Id));
            ItemsView.Refresh();
        }

        protected virtual void OnSelectedItemChanged()
        {
            EventHandler handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        void CreateCommands(
            ISelectedItemCommandFactory<IStartTaskCommand> startTaskCommandFactory,
            ISelectedItemCommandFactory<IStopTaskCommand> stopTaskCommandFactory,
            ISelectedItemCommandFactory<IEditTaskCommand> editTaskCommandFactory,
            ISelectedItemCommandFactory<IMoveUpTaskCommand> moveUpTaskCommandFactory,
            ISelectedItemCommandFactory<IMoveDownTaskCommand> moveDownTaskCommandFactory,
            ISelectedItemCommandFactory<IDeleteTaskCommand> deleteTaskCommandFactory)
        {
            DeleteSelectedTaskCommand = deleteTaskCommandFactory.Create(this);
            StartSelectedTaskCommand = startTaskCommandFactory.Create(this);
            StopSelectedTaskCommand = stopTaskCommandFactory.Create(this);
            EditSelectedTaskCommand = editTaskCommandFactory.Create(this);
            MoveDownSelectedTaskCommand = moveDownTaskCommandFactory.Create(this);
            MoveUpSelectedTaskCommand = moveUpTaskCommandFactory.Create(this);
        }

        ITaskListItemViewModel CreateItemViewModel(Task task)
        {
            return taskListItemViewModelFactory.Create(task, this);
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

        void HandleTaskUpdated(object sender, EntityEventArgs<Task> e)
        {
            ITaskListItemViewModel item = Items.FirstOrDefault(i => i.Id == e.Entity.Id);
            if (item != null)
            {
                Task task = tasksModel.Get(e.Entity.Id);
                item.Update(task);
            }
            ItemsView.Refresh();
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>(tasksModel.GetAll().Select(CreateItemViewModel));
            ItemsView = CollectionViewSource.GetDefaultView(Items);
            ItemsView.SortDescriptions.Add(new SortDescription("Index", ListSortDirection.Ascending));
            ItemsView.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
        }

        void SubscribeToActiveTaskControllerEvents()
        {
            activeTaskController.ActiveTaskIdChanged += HandleActiveTaskIdChanged;
        }

        void SubscribeToTaskModelEvents()
        {
            tasksModel.EntityAdded += HandleTaskAdded;
            tasksModel.EntityDeleted += HandleTaskDeleted;
            tasksModel.EntityUpdated += HandleTaskUpdated;
        }
    }
}