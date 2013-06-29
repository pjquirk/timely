namespace Timely.ViewModels.EditTask
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class EditTaskViewModel : ClosableViewModel, IEditTaskViewModel
    {
        readonly Task task;
        readonly ITasksModel tasksModel;

        public EditTaskViewModel(Guid taskId, ITasksModel tasksModel, IEditTimeBlocksViewModelFactory editTimeBlocksViewModelFactory)
        {
            this.tasksModel = tasksModel;
            task = tasksModel.Get(taskId);
            UpdateTaskCommand = new RelayCommand(UpdateTaskExecute);
            EditTimeBlocksViewModel = editTimeBlocksViewModelFactory.Create(taskId);
        }

        public string Description
        {
            get { return task.Description; }
            set
            {
                task.Description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public IEditTimeBlocksViewModel EditTimeBlocksViewModel { get; private set; }

        public ICommand UpdateTaskCommand { get; private set; }

        void UpdateTaskExecute()
        {
            tasksModel.Update(task);
            Close();
        }
    }
}