namespace BreakFast.Models
{
    public class UpdateBreakFastViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
    }
}
