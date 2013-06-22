namespace Timely.ViewModels.Common
{
    using System;
    using Timely.Models.Common;

    public interface IActiveTaskController
    {
        event EventHandler<EntityIdEventArgs> ActiveTaskIdChanged;

        Guid ActiveTaskId { get; }

        void Start(Guid id);

        void Stop();
    }
}