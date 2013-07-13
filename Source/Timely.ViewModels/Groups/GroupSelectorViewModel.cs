namespace Timely.ViewModels.Groups
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class GroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        readonly IGroupListItemViewModelFactory groupListItemViewModelFactory;
        readonly IGroupsModel groupsModel;

        public GroupSelectorViewModel(
            IGroupsModel groupsModel, INewGroupCommand newGroupCommand, IGroupListItemViewModelFactory groupListItemViewModelFactory)
        {
            NewGroupCommand = newGroupCommand;
            this.groupsModel = groupsModel;
            this.groupListItemViewModelFactory = groupListItemViewModelFactory;
            this.groupsModel.EntityAdded += HandleEntityAdded;
            this.groupsModel.EntityDeleted += HandleEntityDeleted;
            PopulateGroupNames();
        }

        public ObservableCollection<IGroupListItemViewModel> GroupNames { get; private set; }

        public ICommand NewGroupCommand { get; private set; }

        public Guid SelectedGroupId
        {
            get
            {
                if (SelectedItem != null)
                    return SelectedItem.Id;
                return Guid.Empty;
            }
        }

        public IGroupListItemViewModel SelectedItem { get; set; }

        IGroupListItemViewModel CreateItem(Group group)
        {
            return groupListItemViewModelFactory.Create(group);
        }

        void HandleEntityAdded(object sender, EntityEventArgs<Group> e)
        {
            GroupNames.Add(CreateItem(e.Entity.Clone()));
        }

        void HandleEntityDeleted(object sender, EntityIdEventArgs e)
        {
            IGroupListItemViewModel groupListItemViewModel = GroupNames.First(i => i.Id == e.Id);
            GroupNames.Remove(groupListItemViewModel);
        }

        void PopulateGroupNames()
        {
            GroupNames = new ObservableCollection<IGroupListItemViewModel>(groupsModel.GetAll().Select(CreateItem).OrderBy(i => i.Name));
        }
    }
}