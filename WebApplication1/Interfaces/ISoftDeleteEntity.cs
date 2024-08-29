namespace WebApplication1.Interfaces
{
    public interface ISoftDeleteEntity
    {
        public bool? IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
