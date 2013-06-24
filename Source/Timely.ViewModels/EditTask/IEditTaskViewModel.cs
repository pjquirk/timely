namespace Timely.ViewModels.EditTask
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IEditTaskViewModel : IClosableViewModel
    {
        string Description { get; set; }

        ICommand UpdateTaskCommand { get; }
    }
}