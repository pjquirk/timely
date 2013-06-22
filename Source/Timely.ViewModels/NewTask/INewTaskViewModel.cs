namespace Timely.ViewModels.NewTask
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface INewTaskViewModel : IClosableViewModel
    {
        ICommand CreateTaskCommand { get; }

        string Description { get; set; }
    }
}