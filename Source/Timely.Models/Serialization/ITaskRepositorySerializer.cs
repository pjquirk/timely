namespace Timely.Models.Serialization
{
    public interface ITaskRepositorySerializer
    {
        ITaskRepository Deserialize(string fileName);

        void Serialize(ITaskRepository taskRepository, string fileName);
    }
}