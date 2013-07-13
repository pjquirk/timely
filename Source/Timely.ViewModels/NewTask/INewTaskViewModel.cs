namespace Timely.ViewModels.NewTask
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.Groups;

    public interface INewTaskViewModel : IClosableViewModel
    {
        ICommand CreateTaskCommand { get; }

        string Description { get; set; }

        IGroupSelectorViewModel GroupSelectorViewModel { get; }
    }
}