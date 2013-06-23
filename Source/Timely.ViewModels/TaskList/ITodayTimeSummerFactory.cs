namespace Timely.ViewModels.TaskList
{
    public interface ITodayTimeSummerFactory
    {
        ITodayTimeSummer Create(ITaskListItemViewModel taskListItemViewModel);
    }
}