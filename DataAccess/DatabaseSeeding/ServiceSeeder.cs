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
                    ServiceId = 1,
                    Description = "Descripción 1",
                    HourValue = 25.87,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 2,
                    Description = "Descripción 2",
                    HourValue = 31.50,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 3,
                    Description = "Descripción 3",
                    HourValue = 12.41,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 4,
                    Description = "Descripción 4",
                    HourValue = 16.05,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 5,
                    Description = "Descripción 5",
                    HourValue = 8.79,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 6,
                    Description = "Descripción 6",
                    HourValue = 20.33,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 7,
                    Description = "Descripción 7",
                    HourValue = 13.50,
                    IsDeleted = false,
                },
                new Service
                {
                    ServiceId = 8,
                    Description = "Descripción 8",
                    HourValue = 22.89,
                    IsDeleted = false,
                }
            );
        }
    }
}
