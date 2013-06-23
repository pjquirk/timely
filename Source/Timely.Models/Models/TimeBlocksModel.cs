namespace Timely.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Serialization;

    public class TimeBlocksModel : EntityModel<TimeBlock>, ITimeBlocksModel
    {
        public TimeBlocksModel(ITaskListStore taskListStore, IEntityCreator<TimeBlock> entityCreator)
            : base(taskListStore.TimeBlocks, entityCreator)
        {
        }

        public TimeBlock Add(Guid taskId, DateTime start)
        {
            TimeBlock task = CreateEntity(taskId, start);
            AddToStore(task);
            return task;
        }

        public IEnumerable<TimeBlock> GetByTask(Guid taskId)
        {
            return EntityDictionary.Values.Where(t => t.TaskId == taskId);
        }

        TimeBlock CreateEntity(Guid taskId, DateTime start)
        {
            TimeBlock task = EntityCreator.Create();
            task.TaskId = taskId;
            task.Start = start;
            task.End = DateTime.MaxValue;
            return task;
        }
    }
}