namespace Timely.Models.Entities
{
    public class Task : Entity
    {
        public string Description { get; set; }
        
        public int Index { get; set; }
    }
}