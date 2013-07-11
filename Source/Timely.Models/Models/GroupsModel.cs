namespace Timely.Models.Models
{
    using System;
    using System.Collections.Generic;
    using Timely.Models.Common;
    using Timely.Models.Entities;

    public class GroupsModel : EntityModel<Group>, IGroupsModel
    {
        public GroupsModel(IDictionary<Guid, Group> entityDictionary, IEntityCreator<Group> entityCreator)
            : base(entityDictionary, entityCreator)
        {
        }

        public Group Add(string name)
        {
            Group group = CreateEntity(name);
            AddToStore(group);
            return group;
        }

        Group CreateEntity(string description)
        {
            Group group = EntityCreator.Create();
            group.Name = description;
            return group;
        }
    }
}