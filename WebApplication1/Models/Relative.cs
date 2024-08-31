using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class Relative : ISoftDeleteEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Age { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
