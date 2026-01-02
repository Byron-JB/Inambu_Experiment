using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.tblProductionLine>().ToTable("tblProductionLines");
            modelBuilder.Entity<Domain.Entities.tblUser>().ToTable("tblUsers");
            modelBuilder.Entity<Domain.Entities.tblMeasurement>().ToTable("tbMeasurements");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
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

        public DbSet<tblProductionLine> tblProductionLines { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblMeasurement> tbMeasurements { get; set; }
        public DbSet<tblUserRoles> tblUserRoles { get; set; }
        public DbSet<tblExpenditureRequest> tblExpenditureRequests { get; set; }
        public DbSet<tblExpenditureApprovalMembers> tblExpenditureApprovalMembers { get; set; }
    }
}
