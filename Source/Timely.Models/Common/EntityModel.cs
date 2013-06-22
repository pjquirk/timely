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

        public event EventHandler<EntityEventArgs<T>> EntityAdded;
        
        public event EventHandler<EntityIdEventArgs> EntityDeleted;

        protected IEntityCreator<T> EntityCreator { get; private set; }

        protected IDictionary<Guid, T> EntityDictionary { get; private set; }

        public void Delete(Guid id)
        {
            if (EntityDictionary.Remove(id))
                OnEntityDeleted(id);
        }

        public T Get(Guid id)
        {
            return EntityDictionary[id];
        }

        public IEnumerable<T> GetAll()
        {
            return EntityDictionary.Values;
        }

        protected void AddToStore(T entity)
        {
            EntityDictionary.Add(entity.Id, entity);
        }

        protected virtual void OnEntityAdded(T entity)
        {
            EventHandler<EntityEventArgs<T>> handler = EntityAdded;
            if (handler != null)
                handler(this, new EntityEventArgs<T>(entity));
        }

        protected virtual void OnEntityDeleted(Guid id)
        {
            EventHandler<EntityIdEventArgs> handler = EntityDeleted;
            if (handler != null)
                handler(this, new EntityIdEventArgs(id));
        }
    }
}