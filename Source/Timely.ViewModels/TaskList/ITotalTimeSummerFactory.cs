namespace Timely.ViewModels.TaskList
{
    public interface ITotalTimeSummerFactory
    {
        ITotalTimeSummer Create(ITaskListItemViewModel taskListItemViewModel);
    }
}