namespace Timely.Models.Common
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Entities;

    public interface IEntityModel<T>
        where T : Entity, new()
    {
        event EventHandler<EntityEventArgs<T>> EntityAdded;

        event EventHandler<EntityIdEventArgs> EntityDeleted;

        void Delete(Guid id);

        T Get(Guid id);

        IEnumerable<T> GetAll();
    }
}