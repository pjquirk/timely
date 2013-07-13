namespace Timely.ViewModels.Groups
{
    using Timely.Models.Entities;

    public interface IGroupListItemViewModelFactory
    {
        IGroupListItemViewModel Create(Group group);
    }
}