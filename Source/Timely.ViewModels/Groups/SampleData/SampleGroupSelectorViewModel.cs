namespace Timely.ViewModels.Groups.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;

    public class SampleGroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        public SampleGroupSelectorViewModel()
        {
            GroupNames = new ObservableCollection<IGroupListItemViewModel>
                             {
                                 new SampleGroupListItemViewModel { Name = "Group 1" },
                                 new SampleGroupListItemViewModel { Name = "Group 2" },
                                 new SampleGroupListItemViewModel { Name = "Group 3" }
                             };
            SelectedItem = GroupNames[1];
        }

        public ObservableCollection<IGroupListItemViewModel> GroupNames { get; private set; }

        public ICommand NewGroupCommand { get; private set; }
        
        public Guid SelectedGroupId { get; set; }

        public IGroupListItemViewModel SelectedItem { get; set; }
    }
}