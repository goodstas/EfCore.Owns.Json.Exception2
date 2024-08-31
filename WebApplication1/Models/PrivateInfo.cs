using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class PrivateInfo : ISoftDeleteEntity
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = default!;

        public bool? IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
