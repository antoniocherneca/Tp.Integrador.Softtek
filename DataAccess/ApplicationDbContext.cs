using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.DataAccess.DatabaseSeeding;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new ProjectSeeder(),
                new ServiceSeeder(),
                new JobSeeder(),
                new RoleSeeder(),
                new ProjectStatusSeeder(),
            };

            foreach (var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }
        }
    }
}
