namespace Timely.ViewModels.Main
{
    using System;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;
    using Timely.ViewModels.TaskList;

    public class IdleTimeSummer : TimeSummerBase, IIdleTimeSummer
    {
        readonly IStatusBarViewModel statusBarViewModel;

        public IdleTimeSummer(IStatusBarViewModel statusBarViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
            : base(timeBlocksModel, timer)
        {
            this.statusBarViewModel = statusBarViewModel;
        }

        public override void Execute()
        {
            statusBarViewModel.IdleTime = TimeSpan.Zero;
        }
    }
}