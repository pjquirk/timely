namespace Timely.ViewModels.Groups
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class NewGroupViewModel : ClosableViewModel, INewGroupViewModel
    {
        public ICommand CreateGroupCommand { get; private set; }

        public string GroupName { get; set; }
    }
}