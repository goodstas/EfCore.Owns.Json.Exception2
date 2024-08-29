namespace WebApplication1.AppDB
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using WebApplication1.Interfaces;
    using WebApplication1.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");
                entity.HasKey(_ => _.Id);
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("uuid_generate_v4()");

                entity.OwnsOne(e => e.PersonalDetails,
                               b =>
                               {
                                   b.ToJson();
                                   b.OwnsMany(e => e.SubDetails);
                               }
                );

            });

            modelBuilder.Entity<Person>().HasIndex(e => e.Id).HasFilter("\"IsDeleted\" = False").HasDatabaseName("PersonId_Index"); ;
        }

        public override int SaveChanges()
        {
            var softDeleteEntities = this.ChangeTracker
                                                    .Entries<ISoftDeleteEntity>()
                                                    .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);

            foreach (var entity in softDeleteEntities)
            {
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                entity.Property(nameof(ISoftDeleteEntity.IsDeleted)).CurrentValue = true;
                entity.Property(nameof(ISoftDeleteEntity.DeletionTime)).CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
