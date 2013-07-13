namespace Timely.ViewModels.Groups
{
    using System;
    using GalaSoft.MvvmLight;
    using Timely.Models.Entities;

    public class GroupListItemViewModel : ViewModelBase, IGroupListItemViewModel
    {
        readonly Group group;

        public GroupListItemViewModel(Group group)
        {
            this.group = group;
        }

        public Guid Id
        {
            get { return group.Id; }
        }

        public string Name
        {
            get { return group.Name; }
        }
    }
}