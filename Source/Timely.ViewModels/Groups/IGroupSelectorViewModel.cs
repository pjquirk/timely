namespace Timely.ViewModels.Groups
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IGroupSelectorViewModel : IViewModel
    {
        ObservableCollection<string> GroupNames { get; }

        ICommand NewGroupCommand { get; }
    }
}