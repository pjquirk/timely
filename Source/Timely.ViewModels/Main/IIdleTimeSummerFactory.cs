namespace Timely.ViewModels.Main
{
    public interface IIdleTimeSummerFactory
    {
        IIdleTimeSummer Create(IStatusBarViewModel statusBarViewModel);
    }
}