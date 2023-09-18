using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class ProjectSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData
            (
                new Project
                {
                    ProjectId = 1,
                    ProjectName = "Proyecto 1",
                    Address = "Dirección 1",
                    Status = (int)ProjectStatus.Pendiente,
                    IsActive = true
                },
                new Project
                {
                    ProjectId = 2,
                    ProjectName = "Proyecto 2",
                    Address = "Dirección 2",
                    Status = (int)ProjectStatus.Pendiente,
                    IsActive = true
                },
                new Project
                {
                    ProjectId = 3,
                    ProjectName = "Proyecto 3",
                    Address = "Dirección 3",
                    Status = (int)ProjectStatus.Confirmado,
                    IsActive = true
                },
                new Project
                {
                    ProjectId = 4,
                    ProjectName = "Proyecto 4",
                    Address = "Dirección 4",
                    Status = (int)ProjectStatus.Confirmado,
                    IsActive = true
                },
                new Project
                {
                    ProjectId = 5,
                    ProjectName = "Proyecto 5",
                    Address = "Dirección 5",
                    Status = (int)ProjectStatus.Terminado,
                    IsActive = true
                }
            );
        }
    }
}
