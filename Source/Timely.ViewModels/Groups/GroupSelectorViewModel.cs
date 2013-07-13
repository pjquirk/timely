namespace Timely.ViewModels.Groups
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class GroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        readonly IGroupsModel groupsModel;

        public GroupSelectorViewModel(IGroupsModel groupsModel, INewGroupCommand newGroupCommand)
        {
            NewGroupCommand = newGroupCommand;
            this.groupsModel = groupsModel;
            this.groupsModel.EntityAdded += HandleEntityAdded;
            this.groupsModel.EntityDeleted += HandleEntityDeleted;
            PopulateGroupNames();
        }

        public ObservableCollection<string> GroupNames { get; private set; }

        public ICommand NewGroupCommand { get; private set; }

        void HandleEntityAdded(object sender, EntityEventArgs<Group> e)
        {
            GroupNames.Add(e.Entity.Name);
        }

        void HandleEntityDeleted(object sender, EntityIdEventArgs e)
        {
            // GroupNames.Remove(e.Entity.Name);
        }

        void PopulateGroupNames()
        {
            GroupNames = new ObservableCollection<string>(groupsModel.GetAll().Select(g => g.Name).OrderBy(n => n));
        }
    }
}