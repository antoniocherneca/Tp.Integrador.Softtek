using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData
            (
                new Service
                {
                    SeviceId = 1,
                    Description = "Descripción 1",
                    HourValue = 25.87,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 2,
                    Description = "Descripción 2",
                    HourValue = 31.50,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 3,
                    Description = "Descripción 3",
                    HourValue = 12.41,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 4,
                    Description = "Descripción 4",
                    HourValue = 16.05,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 5,
                    Description = "Descripción 5",
                    HourValue = 8.79,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 6,
                    Description = "Descripción 6",
                    HourValue = 20.33,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 7,
                    Description = "Descripción 7",
                    HourValue = 13.50,
                    IsActive = true,
                },
                new Service
                {
                    SeviceId = 8,
                    Description = "Descripción 8",
                    HourValue = 22.89,
                    IsActive = true,
                }
            );
        }
    }
}
