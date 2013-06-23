namespace Timely.ViewModels.Common
{
    using System;
    using Timely.Models.Common;

    public class ActiveTaskController : IActiveTaskController
    {
        Guid activeTaskId;

        public event EventHandler<EntityIdEventArgs> ActiveTaskIdChanged;

        public event EventHandler<EntityIdEventArgs> TaskStarted;

        public event EventHandler<EntityIdEventArgs> TaskStopped;

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
            if (id != Guid.Empty)
                OnTaskStarted(id);
        }

        public void Stop()
        {
            Guid taskId = ActiveTaskId;

            ActiveTaskId = Guid.Empty;

            if (taskId != Guid.Empty)
                OnTaskStopped(taskId);
        }

        protected virtual void OnActiveTaskIdChanged(Guid id)
        {
            EventHandler<EntityIdEventArgs> handler = ActiveTaskIdChanged;
            if (handler != null)
                handler(this, new EntityIdEventArgs(id));
        }

        protected virtual void OnTaskStarted(Guid id)
        {
            EventHandler<EntityIdEventArgs> handler = TaskStarted;
            if (handler != null)
                handler(this, new EntityIdEventArgs(id));
        }

        protected virtual void OnTaskStopped(Guid id)
        {
            EventHandler<EntityIdEventArgs> handler = TaskStopped;
            if (handler != null)
                handler(this, new EntityIdEventArgs(id));
        }
    }
}