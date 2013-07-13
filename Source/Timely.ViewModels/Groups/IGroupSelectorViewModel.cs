namespace Timely.ViewModels.Groups
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IGroupSelectorViewModel : IViewModel
    {
        ObservableCollection<IGroupListItemViewModel> GroupNames { get; }

        ICommand NewGroupCommand { get; }

        Guid SelectedGroupId { get; }

        IGroupListItemViewModel SelectedItem { get; set; }
    }
}