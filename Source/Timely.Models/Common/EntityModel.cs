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
        
        public event EventHandler<EntityEventArgs<T>> EntityUpdated;

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

        public void Update(T entity)
        {
            EntityDictionary[entity.Id] = entity;
            OnEntityUpdated(entity);
        }

        protected void AddToStore(T entity)
        {
            EntityDictionary.Add(entity.Id, entity);
            OnEntityAdded(entity);
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

        protected virtual void OnEntityUpdated(T entity)
        {
            EventHandler<EntityEventArgs<T>> handler = EntityUpdated;
            if (handler != null)
                handler(this, new EntityEventArgs<T>(entity));
        }
    }
}