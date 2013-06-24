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

        public EditTaskViewModel(Guid taskId, ITasksModel tasksModel)
        {
            UpdateTaskCommand = new RelayCommand(UpdateTaskExecute);
            this.tasksModel = tasksModel;
            task = tasksModel.Get(taskId);
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

        public ICommand UpdateTaskCommand { get; private set; }

        void UpdateTaskExecute()
        {
            tasksModel.Update(task);
            Close();
        }
    }
}