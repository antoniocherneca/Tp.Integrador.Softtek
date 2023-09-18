using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class JobSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData
            (
                new Job
                {
                    JobId = 1,
                    JobDate = new DateTime(2020, 1, 15),
                    NumberOfHours = 7,
                    HourValue = 19.80,
                    Cost = 138.60,
                    ProjectId = 3,
                    ServiceId = 1,
                    IsActive = true
                },
                new Job
                {
                    JobId = 2,
                    JobDate = new DateTime(2020, 9, 13),
                    NumberOfHours = 18,
                    HourValue = 26.20,
                    Cost = 1257.60,
                    ProjectId = 3,
                    ServiceId = 2,
                    IsActive = true
                },
                new Job
                {
                    JobId = 3,
                    JobDate = new DateTime(2019, 3, 21),
                    NumberOfHours = 22,
                    HourValue = 16.80,
                    Cost = 369.60,
                    ProjectId = 3,
                    ServiceId = 3,
                    IsActive = true
                },
                new Job
                {
                    JobId = 4,
                    JobDate = new DateTime(2016, 9, 2),
                    NumberOfHours = 21,
                    HourValue = 18.90,
                    Cost = 396.90,
                    ProjectId = 4,
                    ServiceId = 1,
                    IsActive = true
                },
                new Job
                {
                    JobId = 5,
                    JobDate = new DateTime(2017, 12, 15),
                    NumberOfHours = 23,
                    HourValue = 31.25,
                    Cost = 718.75,
                    ProjectId = 4,
                    ServiceId = 2,
                    IsActive = true
                },
                new Job
                {
                    JobId = 6,
                    JobDate = new DateTime(2019, 2, 5),
                    NumberOfHours = 12,
                    HourValue = 28.19,
                    Cost = 338.28,
                    ProjectId = 5,
                    ServiceId = 1,
                    IsActive = true
                },
                new Job
                {
                    JobId = 7,
                    JobDate = new DateTime(2018, 9, 22),
                    NumberOfHours = 23,
                    HourValue = 29.89,
                    Cost = 387.47,
                    ProjectId = 5,
                    ServiceId = 2,
                    IsActive = true
                },
                new Job
                {
                    JobId = 8,
                    JobDate = new DateTime(2017, 12, 11),
                    NumberOfHours = 24,
                    HourValue = 30.12,
                    Cost = 722.88,
                    ProjectId = 5,
                    ServiceId = 3,
                    IsActive = true
                },
                new Job
                {
                    JobId = 9,
                    JobDate = new DateTime(2019, 11, 29),
                    NumberOfHours = 26,
                    HourValue = 21.54,
                    Cost = 560.04,
                    ProjectId = 5,
                    ServiceId = 4,
                    IsActive = true
                },
                new Job
                {
                    JobId = 10,
                    JobDate = new DateTime(2021, 10, 4),
                    NumberOfHours = 32,
                    HourValue = 30.35,
                    Cost = 971.20,
                    ProjectId = 4,
                    ServiceId = 3,
                    IsActive = true
                },
                new Job
                {
                    JobId = 11,
                    JobDate = new DateTime(2020, 8, 18),
                    NumberOfHours = 19,
                    HourValue = 24.80,
                    Cost = 471.20,
                    ProjectId = 4,
                    ServiceId = 4,
                    IsActive = true
                },
                new Job
                {
                    JobId = 12,
                    JobDate = new DateTime(2021, 3, 26),
                    NumberOfHours = 18,
                    HourValue = 29.45,
                    Cost = 530.10,
                    ProjectId = 3,
                    ServiceId = 4,
                    IsActive = true
                },
                new Job
                {
                    JobId = 13,
                    JobDate = new DateTime(2022, 1, 5),
                    NumberOfHours = 31,
                    HourValue = 30.24,
                    Cost = 937.44,
                    ProjectId = 5,
                    ServiceId = 5,
                    IsActive = true
                }
            );
        }
    }
}
