namespace Timely.ViewModels.Main
{
    using System;
    using Timely.ViewModels.Base;

    public interface IStatusBarViewModel : IViewModel
    {
        DateTime DayStartTime { get; }
    }
}