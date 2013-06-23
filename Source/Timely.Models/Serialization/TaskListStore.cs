namespace Timely.Models.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using Timely.Models.Entities;

    public class TaskListStore : ITaskListStore
    {
        readonly ITaskRepositorySerializer taskRepositorySerializer;
        readonly ITaskListStoreFilenameProvider taskListStoreFilenameProvider;
        ITaskRepository taskRepository;

        public TaskListStore(ITaskRepositorySerializer taskRepositorySerializer, ITaskListStoreFilenameProvider taskListStoreFilenameProvider)
        {
            this.taskRepositorySerializer = taskRepositorySerializer;
            this.taskListStoreFilenameProvider = taskListStoreFilenameProvider;
            taskRepository = new TaskRepository();
        }

        public IDictionary<Guid, Task> Tasks
        {
            get { return taskRepository.Tasks; }
        }

        public IDictionary<Guid, TimeBlock> TimeBlocks
        {
            get { return taskRepository.TimeBlocks; }
        }

        public void Load()
        {
            try
            {
                taskRepository = taskRepositorySerializer.Deserialize(taskListStoreFilenameProvider.GetFileName());
            }
            catch (FileNotFoundException)
            {
                // Assume we're starting for the first time
                taskRepository = new TaskRepository();
            }
            catch (IOException)
            {
                taskRepository = null;
            }
            catch (SerializationException)
            {
                taskRepository = null;
            }
            catch (XmlException)
            {
                taskRepository = null;
            }
        }

        public void Save()
        {
            taskRepositorySerializer.Serialize(taskRepository, taskListStoreFilenameProvider.GetFileName());
        }
    }
}