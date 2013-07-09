namespace Timely.ViewModels.TaskList
{
    using System.Collections.Generic;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public abstract class TaskItemTimeSummerBase : TimeSummerBase
    {
        protected TaskItemTimeSummerBase(ITaskListItemViewModel taskListItemViewModel, ITimeBlocksModel timeBlocksModel, ITimer timer)
            : base(timeBlocksModel, timer)
        {
            TaskListItemViewModel = taskListItemViewModel;
        }

        protected ITaskListItemViewModel TaskListItemViewModel { get; private set; }

        protected IEnumerable<TimeBlock> GetTimeBlocks()
        {
            return TimeBlocksModel.GetByTask(TaskListItemViewModel.Id);
        }
    }
}