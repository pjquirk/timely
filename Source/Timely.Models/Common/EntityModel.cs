namespace Timely.Models.Common
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Entities;

    public abstract class EntityModel<T> : IEntityModel<T>
        where T : Entity, new()
    {
        protected EntityModel(IDictionary<Guid, T> entityDictionary, IEntityCreator<T> entityCreator)
        {
            EntityDictionary = entityDictionary;
            EntityCreator = entityCreator;
        }

        protected IEntityCreator<T> EntityCreator { get; private set; }
        protected IDictionary<Guid, T> EntityDictionary { get; private set; }

        public T Get(Guid id)
        {
            return EntityDictionary[id];
        }

        protected void AddToStore(T entity)
        {
            EntityDictionary.Add(entity.Id, entity);
        }
    }
}