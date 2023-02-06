using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BreakFast.Entity
{
    public class BaseEntity
    {

        public Guid Id { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Createdby { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
