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
        TimeBlock activeTimeBlock;

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
            activeTimeBlock = timeBlocksModel.Add(e.Id, Now);
        }

        void HandleTaskStopped(object sender, EntityIdEventArgs e)
        {
            activeTimeBlock.End = Now;
            timeBlocksModel.Update(activeTimeBlock);
            activeTimeBlock = null;
        }

        void SubscribeToActiveTaskControllerEvents()
        {
            activeTaskController.TaskStarted += HandleTaskStarted;
            activeTaskController.TaskStopped += HandleTaskStopped;
        }
    }
}