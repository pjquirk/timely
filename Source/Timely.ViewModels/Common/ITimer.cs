namespace Timely.ViewModels.Common
{
    public interface ITimer
    {
        void Subscribe(ITimerClient timerClient);
        
        void Unsubscribe(ITimerClient timerClient);
    }
}