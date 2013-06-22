namespace Timely.ViewModels.Common
{
    using System;
    using Timely.Models.Common;

    public class ActiveTaskController : IActiveTaskController
    {
        Guid activeTaskId;
        public event EventHandler<EntityIdEventArgs> ActiveTaskIdChanged;

        public Guid ActiveTaskId
        {
            get { return activeTaskId; }
            private set
            {
                if (activeTaskId != value)
                {
                    activeTaskId = value;
                    OnActiveTaskIdChanged(value);
                }
            }
        }

        public void Start(Guid id)
        {
            Stop();
            ActiveTaskId = id;
        }

        public void Stop()
        {
            ActiveTaskId = Guid.Empty;
        }

        protected virtual void OnActiveTaskIdChanged(Guid id)
        {
            EventHandler<EntityIdEventArgs> handler = ActiveTaskIdChanged;
            if (handler != null)
                handler(this, new EntityIdEventArgs(id));
        }
    }
}