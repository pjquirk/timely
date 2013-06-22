namespace Timely.Models.Common
{
    using System;
    using Timely.Models.Entities;

    public class EntityCreator<T> : IEntityCreator<T>
        where T : Entity, new()
    {
        public T Create()
        {
            return new T { Id = Guid.NewGuid() };
        }
    }
}