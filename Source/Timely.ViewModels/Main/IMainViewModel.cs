namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.TaskList;

    public interface IMainViewModel : IViewModel
    {
        string Caption { get; set; }

        ICommand NewTaskCommand { get; }

        IStatusBarViewModel StatusBarViewModel { get; }

        ITaskListViewModel TaskListViewModel { get; }
    }
}