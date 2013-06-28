namespace Timely.ViewModels.EditTask
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class EditTaskViewModel : ClosableViewModel, IEditTaskViewModel
    {
        readonly Task task;
        readonly ITasksModel tasksModel;
        readonly ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory;
        readonly ITimeBlocksModel timeBlocksModel;

        public EditTaskViewModel(
            Guid taskId,
            ITasksModel tasksModel,
            ITimeBlocksModel timeBlocksModel,
            ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory)
        {
            UpdateTaskCommand = new RelayCommand(UpdateTaskExecute);
            this.tasksModel = tasksModel;
            this.timeBlocksModel = timeBlocksModel;
            this.timeBlockListItemViewModelFactory = timeBlockListItemViewModelFactory;
            task = tasksModel.Get(taskId);
            PopulateItems();
        }

        public string Description
        {
            get
            {
                return task.Description;
            }
            set
            {
                task.Description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public ObservableCollection<ITimeBlockListItemViewModel> Items { get; private set; }

        public ICommand UpdateTaskCommand { get; private set; }

        ITimeBlockListItemViewModel CreateTimeBlockListItemViewModel(TimeBlock t)
        {
            return timeBlockListItemViewModelFactory.Create(t);
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITimeBlockListItemViewModel>(
                timeBlocksModel.GetByTask(task.Id).Select(CreateTimeBlockListItemViewModel));
        }

        void UpdateTaskExecute()
        {
            tasksModel.Update(task);
            Close();
        }
    }
}