namespace Timely.ViewModels.Groups
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using GalaSoft.MvvmLight;
    using Timely.Models.Models;

    public class GroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        readonly IGroupsModel groupsModel;

        public GroupSelectorViewModel(IGroupsModel groupsModel)
        {
            this.groupsModel = groupsModel;
            PopulateGroupNames();
        }

        void PopulateGroupNames()
        {
            GroupNames = new ObservableCollection<string>(
                groupsModel.GetAll().Select(g => g.Name).OrderBy(n => n));
        }

        public ObservableCollection<string> GroupNames { get; private set; }
    }
}