namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.ViewModels.NewTask;
    using Timely.ViewModels.TaskList;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        readonly IApplicationCaptionMediator applicationCaptionMediator;
        string caption;

        public MainViewModel(
            INewTaskCommand newTaskCommand,
            ITaskListViewModel taskListViewModel,
            IStatusBarViewModel statusBarViewModel,
            IApplicationCaptionMediatorFactory applicationCaptionMediatorFactory)
        {
            NewTaskCommand = newTaskCommand;
            TaskListViewModel = taskListViewModel;
            StatusBarViewModel = statusBarViewModel;
            applicationCaptionMediator = applicationCaptionMediatorFactory.Create(this);
        }

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                RaisePropertyChanged(() => Caption);
            }
        }

        public ICommand NewTaskCommand { get; private set; }

        public IStatusBarViewModel StatusBarViewModel { get; private set; }

        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}