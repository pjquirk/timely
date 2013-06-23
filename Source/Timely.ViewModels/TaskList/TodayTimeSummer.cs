namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class TodayTimeSummer : TimeSummerBase, ITodayTimeSummer
    {
        public TodayTimeSummer(ITaskListItemViewModel taskListItemViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
            : base(taskListItemViewModel, timeBlocksModel, timer)
        {
        }

        public override void Execute()
        {
            IEnumerable<TimeBlock> timeBlocks = GetTimeBlocks();
            double totalSeconds = timeBlocks.Where(BlockIsToday).Sum((Func<TimeBlock, double>)GetDurationForBlock);
            TaskListItemViewModel.TodayTime = TimeSpan.FromSeconds(totalSeconds);
        }

        bool BlockIsToday(TimeBlock timeBlock)
        {
            return timeBlock.Start.Date == DateTime.Today;
        }
    }
}