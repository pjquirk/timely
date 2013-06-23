namespace Timely.ViewModels.Common
{
    using System;
    using System.Linq;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class TimeBlockMediator : ITimeBlockMediator
    {
        readonly IActiveTaskController activeTaskController;
        readonly ITimeBlocksModel timeBlocksModel;

        public TimeBlockMediator(IActiveTaskController activeTaskController, ITimeBlocksModel timeBlocksModel)
        {
            this.activeTaskController = activeTaskController;
            this.timeBlocksModel = timeBlocksModel;
            SubscribeToActiveTaskControllerEvents();
        }

        DateTime Now
        {
            get { return DateTime.UtcNow; }
        }

        void HandleTaskStarted(object sender, EntityIdEventArgs e)
        {
            timeBlocksModel.Add(e.Id, Now);
        }

        void HandleTaskStopped(object sender, EntityIdEventArgs e)
        {
            TimeBlock timeBlock = timeBlocksModel.GetByTask(e.Id).Single(t => t.End == DateTime.MaxValue);
            timeBlock.End = Now;
        }

        void SubscribeToActiveTaskControllerEvents()
        {
            activeTaskController.TaskStarted += HandleTaskStarted;
            activeTaskController.TaskStopped += HandleTaskStopped;
        }
    }
}