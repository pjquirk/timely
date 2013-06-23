namespace Timely.ViewModels.Common
{
    public interface ITimeBlockMediatorFactory
    {
        ITimeBlockMediator Create(IActiveTaskController activeTaskController);
    }
}