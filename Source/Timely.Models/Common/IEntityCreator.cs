namespace Timely.Models.Common
{
    using Timely.Models.Entities;

    public interface IEntityCreator<out T>
        where T : Entity, new()
    {
        T Create();
    }
}