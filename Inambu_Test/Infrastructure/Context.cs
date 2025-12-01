using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.tblProductionLine>().ToTable("tblProductionLines");
            modelBuilder.Entity<Domain.Entities.tblUser>().ToTable("tblUsers");
            modelBuilder.Entity<Domain.Entities.tbMeasurement>().ToTable("tbMeasurements");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.Now;
                E.Property("IsActive").CurrentValue = true;
                E.Property("IsDeleted").CurrentValue = false;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("ModifiedDate").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Domain.Entities.tblProductionLine> tblProductionLines { get; set; }
        public DbSet<Domain.Entities.tblUser> tblUsers { get; set; }
        public DbSet<Domain.Entities.tbMeasurement> tbMeasurements{  get; set; }
    }
}
