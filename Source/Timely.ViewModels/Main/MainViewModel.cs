namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.ViewModels.NewTask;
    using Timely.ViewModels.TaskList;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(INewTaskCommand newTaskCommand)
        {
            NewTaskCommand = newTaskCommand;
        }

        public ICommand NewTaskCommand { get; private set; }

        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}