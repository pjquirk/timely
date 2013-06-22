namespace Timely.Models.Common
{
    using System;

    public class EntityIdEventArgs : EventArgs
    {
        public EntityIdEventArgs(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}