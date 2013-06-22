namespace Timely.Models.Common
{
    using System;
    using Timely.Models.Entities;

    public interface IEntityModel<out T>
        where T : Entity, new()
    {
        T Get(Guid id);
    }
}