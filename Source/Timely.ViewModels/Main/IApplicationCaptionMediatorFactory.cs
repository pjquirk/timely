namespace Timely.ViewModels.Main
{
    public interface IApplicationCaptionMediatorFactory
    {
        IApplicationCaptionMediator Create(IMainViewModel mainViewModel);
    }
}