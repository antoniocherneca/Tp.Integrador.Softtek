using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class ProjectStatusSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectStatus>().HasData
            (
                new ProjectStatus
                {
                    ProjectStatusId = 1,
                    ProjectStatusName = "Pendiente",
                    IsDeleted = false,
                },
                new ProjectStatus
                {
                    ProjectStatusId = 2,
                    ProjectStatusName = "Confirmado",
                    IsDeleted = false,
                },
                new ProjectStatus
                {
                    ProjectStatusId = 3,
                    ProjectStatusName = "Terminado",
                    IsDeleted = false,
                }
            );
        }
    }
}
