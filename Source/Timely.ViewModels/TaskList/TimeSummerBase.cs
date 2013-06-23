namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public abstract class TimeSummerBase : ITimerClient
    {
        readonly ITimeBlocksModel timeBlocksModel;
        readonly ITimer timer;

        protected TimeSummerBase(ITaskListItemViewModel taskListItemViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
        {
            TaskListItemViewModel = taskListItemViewModel;
            this.timeBlocksModel = timeBlocksModel;
            this.timer = timer;
            timer.Subscribe(this);
        }

        protected ITaskListItemViewModel TaskListItemViewModel { get; private set; }

        public abstract void Execute();

        protected double GetDurationForBlock(TimeBlock timeBlock)
        {
            DateTime end = (timeBlock.End != DateTime.MaxValue) ? timeBlock.End : DateTime.UtcNow;
            TimeSpan duration = end - timeBlock.Start;
            return duration.TotalSeconds;
        }

        protected IEnumerable<TimeBlock> GetTimeBlocks()
        {
            return timeBlocksModel.GetByTask(TaskListItemViewModel.Id);
        }
    }
}