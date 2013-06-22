namespace Timely.Models.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Timely.Models.Entities;

    [DataContract]
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository()
        {
            Tasks = new Dictionary<Guid, Task>();
        }

        [DataMember]
        public IDictionary<Guid, Task> Tasks { get; private set; }
    }
}