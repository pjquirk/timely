namespace Timely.ViewModels.Main.SampleData
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.ViewModels.TaskList;
    using Timely.ViewModels.TaskList.SampleData;

    public class SampleMainViewModel : ViewModelBase, IMainViewModel
    {
        public SampleMainViewModel()
        {
            StatusBarViewModel = new SampleStatusBarViewModel();
            TaskListViewModel = new SampleTaskListViewModel();
        }

        public string Caption { get; set; }

        public ICommand NewTaskCommand { get; private set; }

        public IStatusBarViewModel StatusBarViewModel { get; private set; }
        
        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}