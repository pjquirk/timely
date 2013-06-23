namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class TotalTimeSummer : ITotalTimeSummer
    {
        readonly ITaskListItemViewModel taskListItemViewModel;
        readonly ITimeBlocksModel timeBlocksModel;
        readonly ITimer timer;

        public TotalTimeSummer(ITaskListItemViewModel taskListItemViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
        {
            this.taskListItemViewModel = taskListItemViewModel;
            this.timeBlocksModel = timeBlocksModel;
            this.timer = timer;
            timer.Subscribe(this);
        }

        public void Execute()
        {
            IEnumerable<TimeBlock> timeBlocks = timeBlocksModel.GetByTask(taskListItemViewModel.Id);
            double totalSeconds = timeBlocks.Sum((Func<TimeBlock, double>)GetDurationForBlock);
            taskListItemViewModel.TotalTime = TimeSpan.FromSeconds(totalSeconds);
        }

        double GetDurationForBlock(TimeBlock timeBlock)
        {
            DateTime end = (timeBlock.End != DateTime.MaxValue) ? timeBlock.End : DateTime.UtcNow;
            TimeSpan duration = end - timeBlock.Start;
            return duration.TotalSeconds;
        }
    }
}