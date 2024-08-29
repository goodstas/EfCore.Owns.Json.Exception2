using System.Text.Json.Serialization;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class Person : ISoftDeleteEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Details PersonalDetails { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
