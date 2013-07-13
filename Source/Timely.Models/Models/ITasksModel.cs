namespace Timely.Models.Models
{
    using System;
    using Timely.Models.Common;
    using Timely.Models.Entities;

    public interface ITasksModel : IEntityModel<Task>
    {
        Task Add(string description);
        
        Task Add(string description, Guid groupId);

        void SetTaskIndex(Guid id, int index);
    }
}