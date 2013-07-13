namespace Timely.ViewModels.Groups
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.Models.Models;

    public class GroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        readonly IGroupsModel groupsModel;

        public GroupSelectorViewModel(IGroupsModel groupsModel, INewGroupCommand newGroupCommand)
        {
            NewGroupCommand = newGroupCommand;
            this.groupsModel = groupsModel;
            PopulateGroupNames();
        }

        public ObservableCollection<string> GroupNames { get; private set; }

        public ICommand NewGroupCommand { get; private set; }

        void PopulateGroupNames()
        {
            GroupNames = new ObservableCollection<string>(groupsModel.GetAll().Select(g => g.Name).OrderBy(n => n));
        }
    }
}