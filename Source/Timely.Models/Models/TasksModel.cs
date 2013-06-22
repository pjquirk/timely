namespace Timely.Models.Models
{
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Serialization;

    public class TasksModel : EntityModel<Task>, ITasksModel
    {
        public TasksModel(ITaskListStore taskListStore, IEntityCreator<Task> entityCreator)
            : base(taskListStore.Tasks, entityCreator)
        {
        }

        public Task Add(string description)
        {
            Task task = CreateEntity(description);
            AddToStore(task);
            OnEntityAdded(task);
            return task;
        }

        Task CreateEntity(string description)
        {
            Task task = EntityCreator.Create();
            task.Description = description;
            return task;
        }
    }
}