using Microsoft.EntityFrameworkCore;
using Register.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Infra.Data
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<StockBroker> StockBrokers { get; set; }
        public DbSet<UserConfiguration> UserConfigurations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "testuser@test.com";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "testuser@test.com";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}