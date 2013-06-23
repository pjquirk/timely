namespace Timely.Models.Models
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Common;
    using Timely.Models.Entities;

    public interface ITimeBlocksModel : IEntityModel<TimeBlock>
    {
        TimeBlock Add(Guid taskId, DateTime start);

        IEnumerable<TimeBlock> GetByTask(Guid taskId);
    }
}