namespace BreakFast.Entity
{
    public class Breakfast : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; } 
    }
}
