namespace Timely.ViewModels.Main
{
    using System;
    using System.Linq;
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

        TimeSpan TimeSinceStart
        {
            get
            {
                if (statusBarViewModel.DayStartTime != DateTime.MinValue)
                    return DateTime.Now - statusBarViewModel.DayStartTime;
                return TimeSpan.Zero;
            }
        }

        TimeSpan TimeTrackedToday
        {
            get
            {
                double timeToday = TimeBlocksModel.GetAll().Where(t => t.Start.Date == DateTime.Today).Sum(t => GetDurationForBlock(t));
                return TimeSpan.FromSeconds(timeToday);
            }
        }

        public override void Execute()
        {
            if (TimeSinceStart > TimeSpan.Zero)
                statusBarViewModel.IdleTime = TimeSinceStart - TimeTrackedToday;
            else
                statusBarViewModel.IdleTime = TimeSpan.Zero;
        }
    }
}