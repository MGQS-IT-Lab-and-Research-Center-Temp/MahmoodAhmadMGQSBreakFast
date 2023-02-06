using BreakFast.Entity;

namespace BreakFast.Models
{
    public class BreakFastViewModel : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
    }
}
