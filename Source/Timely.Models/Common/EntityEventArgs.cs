namespace Timely.Models.Common
{
    using System;
    using Timely.Models.Entities;

    public class EntityEventArgs<T> : EventArgs
        where T : Entity
    {
        public EntityEventArgs(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }
    }
}