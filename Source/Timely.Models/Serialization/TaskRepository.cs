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
            Groups = new Dictionary<Guid, Group>();
            Tasks = new Dictionary<Guid, Task>();
            TimeBlocks = new Dictionary<Guid, TimeBlock>();
        }

        [DataMember]
        public IDictionary<Guid, Group> Groups { get; private set; }

        [DataMember]
        public IDictionary<Guid, Task> Tasks { get; private set; }

        [DataMember]
        public IDictionary<Guid, TimeBlock> TimeBlocks { get; private set; }
    }
}