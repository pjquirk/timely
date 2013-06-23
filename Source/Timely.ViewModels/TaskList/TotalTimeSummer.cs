namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class TotalTimeSummer : TimeSummerBase, ITotalTimeSummer
    {
        public TotalTimeSummer(ITaskListItemViewModel taskListItemViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
            : base(taskListItemViewModel, timeBlocksModel, timer)
        {
        }

        public override void Execute()
        {
            IEnumerable<TimeBlock> timeBlocks = GetTimeBlocks();
            double totalSeconds = timeBlocks.Sum((Func<TimeBlock, double>)GetDurationForBlock);
            TaskListItemViewModel.TotalTime = TimeSpan.FromSeconds(totalSeconds);
        }
    }
}