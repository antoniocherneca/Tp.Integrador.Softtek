using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData
            (
                new Role
                {
                    RoleId = 1,
                    RoleName = "Administrador",
                    IsDeleted = false,
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Consultor",
                    IsDeleted = false,
                }
            );
        }
    }
}
