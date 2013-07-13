namespace Timely.ViewModels.Groups
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface INewGroupViewModel : IClosableViewModel
    {
        ICommand CreateGroupCommand { get; }

        string GroupName { get; set; }
    }
}