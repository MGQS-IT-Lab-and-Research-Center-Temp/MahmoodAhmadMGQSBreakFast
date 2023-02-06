using BreakFast.Entity;
using BreakFast.Models.Response;

namespace BreakFast.Models
{
    public class CreateBreakfastViewModel : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
    }
}
