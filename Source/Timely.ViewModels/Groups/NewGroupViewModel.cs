namespace Timely.ViewModels.Groups
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class NewGroupViewModel : ClosableViewModel, INewGroupViewModel
    {
        readonly IGroupsModel groupsModel;

        public NewGroupViewModel(IGroupsModel groupsModel)
        {
            this.groupsModel = groupsModel;
            CreateGroupCommand = new RelayCommand(CreateGroupExecute);
        }

        public ICommand CreateGroupCommand { get; private set; }

        public string GroupName { get; set; }

        void CreateGroupExecute()
        {
            groupsModel.Add(GroupName);
            Close();
        }
    }
}