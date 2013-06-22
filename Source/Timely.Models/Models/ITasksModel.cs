namespace Timely.Models.Models
{
    using Timely.Models.Common;
    using Timely.Models.Entities;

    public interface ITasksModel : IEntityModel<Task>
    {
        Task Add(string description);
    }
}