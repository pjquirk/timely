namespace Timely.Models.Models
{
    using System;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Serialization;

    public class GroupsModel : EntityModel<Group>, IGroupsModel
    {
        public GroupsModel(ITaskListStore taskListStore, IEntityCreator<Group> entityCreator)
            : base(taskListStore.Groups, entityCreator)
        {
        }

        public Group Add(string name)
        {
            Group group = CreateEntity(name);
            AddToStore(group);
            return group;
        }

        public string GetGroupName(Guid groupId)
        {
            if (groupId == Guid.Empty)
                return null;
            return Get(groupId).Name;
        }

        Group CreateEntity(string description)
        {
            Group group = EntityCreator.Create();
            group.Name = description;
            return group;
        }
    }
}