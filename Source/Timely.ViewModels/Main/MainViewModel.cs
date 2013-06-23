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
            IApplicationCaptionMediatorFactory applicationCaptionMediatorFactory)
        {
            NewTaskCommand = newTaskCommand;
            TaskListViewModel = taskListViewModel;
            applicationCaptionMediator = applicationCaptionMediatorFactory.Create(this);
        }

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                RaisePropertyChanged(() => Caption);
            }
        }

        public ICommand NewTaskCommand { get; private set; }

        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}