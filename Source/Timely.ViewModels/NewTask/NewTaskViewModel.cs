namespace Timely.ViewModels.NewTask
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class NewTaskViewModel : ClosableViewModel, INewTaskViewModel
    {
        readonly ITasksModel tasksModel;

        public NewTaskViewModel(ITasksModel tasksModel)
        {
            this.tasksModel = tasksModel;
            CreateTaskCommand = new RelayCommand(CreateTaskExecute);
        }

        public ICommand CreateTaskCommand { get; private set; }

        public string Description { get; set; }

        void CreateTaskExecute()
        {
            tasksModel.Add(Description);
            Close();
        }
    }
}