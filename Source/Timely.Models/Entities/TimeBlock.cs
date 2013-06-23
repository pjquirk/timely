namespace Timely.Models.Entities
{
    using System;

    public class TimeBlock : Entity
    {
        public DateTime End { get; set; }

        public DateTime Start { get; set; }
     
        public Guid TaskId { get; set; }
    }
}