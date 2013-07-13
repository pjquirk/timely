namespace Timely.ViewModels.Groups
{
    using System;
    using Timely.ViewModels.Base;

    public interface IGroupListItemViewModel : IViewModel
    {
        Guid Id { get; }

        string Name { get; }
    }
}