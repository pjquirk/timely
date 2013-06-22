namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.TaskList;

    public interface IMainViewModel : IViewModel
    {
        ICommand NewTaskCommand { get; }
        
        ITaskListViewModel TaskListViewModel { get; }
    }
}