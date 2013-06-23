namespace Timely.Models.Serialization
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Entities;

    public interface ITaskRepository
    {
        IDictionary<Guid, Task> Tasks { get; }

        IDictionary<Guid, TimeBlock> TimeBlocks { get; }
    }
}