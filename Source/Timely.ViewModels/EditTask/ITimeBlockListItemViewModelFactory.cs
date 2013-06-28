namespace Timely.ViewModels.EditTask
{
    using Timely.Models.Entities;

    public interface ITimeBlockListItemViewModelFactory
    {
        ITimeBlockListItemViewModel Create(TimeBlock timeBlock);
    }
}