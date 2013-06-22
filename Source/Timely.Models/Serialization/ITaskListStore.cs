namespace Timely.Models.Serialization
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Entities;

    public interface ITaskListStore
    {
        IDictionary<Guid, Task> Tasks { get; }

        void Load();

        void Save();
    }
}