namespace Timely.ViewModels.TaskList
{
    using System;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public abstract class TimeSummerBase : ITimerClient
    {
        readonly ITimer timer;

        protected TimeSummerBase(ITimeBlocksModel timeBlocksModel, ITimer timer)
        {
            this.TimeBlocksModel = timeBlocksModel;
            this.timer = timer;
            timer.Subscribe(this);
        }

        public ITimeBlocksModel TimeBlocksModel { get; private set; }

        public abstract void Execute();

        protected double GetDurationForBlock(TimeBlock timeBlock)
        {
            DateTime end = (timeBlock.End != DateTime.MaxValue) ? timeBlock.End : DateTime.UtcNow;
            TimeSpan duration = end - timeBlock.Start;
            return duration.TotalSeconds;
        }
    }
}