namespace Timely.ViewModels.EditTask
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.Groups;

    public interface IEditTaskViewModel : IClosableViewModel
    {
        string Description { get; set; }

        IEditTimeBlocksViewModel EditTimeBlocksViewModel { get; }

        IGroupSelectorViewModel GroupSelectorViewModel { get; }

        ICommand UpdateTaskCommand { get; }
    }
}