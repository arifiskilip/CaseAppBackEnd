using Core.Domain;
using Core.Security.Entitites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
	public class CaseAppContext : DbContext
	{
		public CaseAppContext(DbContextOptions<CaseAppContext> options) : base(options)
		{
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entities = ChangeTracker.Entries<Entity<int>>();
			foreach (var entity in entities)
			{
				if (entity.State == EntityState.Modified)
				{
					entity.Entity.UpdatedDate = DateTime.Now;

				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}

		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<Domain.Entities.Task> Tasks { get; set; }
		public DbSet<CompletedTask> CompletedTasks { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }
		public DbSet<UnitType> UnitTypes { get; set; }
		public DbSet<User> Users { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Domain.Entities.Task>()
				.HasOne(t => t.TaskType)
				.WithMany(tt => tt.Tasks)
				.HasForeignKey(t => t.TaskTypeId);

			modelBuilder.Entity<Domain.Entities.Task>()
				.HasOne(t => t.City)
				.WithMany(c => c.Tasks)
				.HasForeignKey(t => t.CityId);

			modelBuilder.Entity<CompletedTask>()
				.HasOne(ct => ct.Task)
				.WithMany(t => t.CompletedTasks)
				.HasForeignKey(ct => ct.TaskId);

			modelBuilder.Entity<CompletedTask>()
				.HasOne(ct => ct.User)
				.WithMany(u => u.CompletedTasks)
				.HasForeignKey(ct => ct.UserId);

			modelBuilder.Entity<City>()
				.HasOne(c => c.Region)
				.WithMany(r => r.Cities)
				.HasForeignKey(c => c.RegionId);

			modelBuilder.Entity<TaskType>()
				.HasOne(tt => tt.UnitType)
				.WithMany(ut => ut.TaskTypes)
				.HasForeignKey(tt => tt.UnitTypeId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
