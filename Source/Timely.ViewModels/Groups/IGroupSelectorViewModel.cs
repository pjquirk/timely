namespace Timely.ViewModels.Groups
{
    using System.Collections.ObjectModel;
    using Timely.ViewModels.Base;

    public interface IGroupSelectorViewModel : IViewModel
    {
        ObservableCollection<string> GroupNames { get; }
    }
}