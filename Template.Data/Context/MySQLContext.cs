using Microsoft.EntityFrameworkCore;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());

            //ApplyGlobalStandards(modelBuilder);
            //SeedData(modelBuilder);
        }
    }
}
