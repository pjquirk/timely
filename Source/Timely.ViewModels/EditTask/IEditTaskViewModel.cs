namespace Timely.ViewModels.EditTask
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IEditTaskViewModel : IClosableViewModel
    {
        string Description { get; set; }

        IEditTimeBlocksViewModel EditTimeBlocksViewModel { get; }

        ICommand UpdateTaskCommand { get; }
    }
}