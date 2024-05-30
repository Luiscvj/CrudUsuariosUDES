using CrudUdes.Domain.Entities;
using CrudUdes.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrudUdes.Persistence
{
    public class CrudUdesContext : DbContext
    {
        public CrudUdesContext(DbContextOptions options ) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            DataSeeding.Seed(modelBuilder);
        }
    }
}
