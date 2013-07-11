namespace Timely.Models.Entities
{
    using System;

    public class Task : Entity
    {
        public string Description { get; set; }

        public Guid GroupId { get; set; }

        public int Index { get; set; }
    }
}