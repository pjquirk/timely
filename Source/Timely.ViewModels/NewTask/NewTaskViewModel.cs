namespace Timely.ViewModels.NewTask
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.ViewModels.Base;

    public class NewTaskViewModel : ClosableViewModel, INewTaskViewModel
    {
        public NewTaskViewModel()
        {
            CreateTaskCommand = new RelayCommand(CreateTaskExecute);
        }

        public ICommand CreateTaskCommand { get; private set; }

        public string Description { get; set; }

        void CreateTaskExecute()
        {
            // TODO: Create the task
            Close();
        }
    }
}