using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    UserId = 1,
                    UserName = "test Admin",
                    Dni = 11111111,
                    Password = "123456",
                    Type = (int)UserType.Administrador,
                    IsActive = true
                },
                new User
                {
                    UserId = 2,
                    UserName = "test User",
                    Dni = 22222222,
                    Password = "123456",
                    Type = (int)UserType.Consultor,
                    IsActive = true
                },
                new User
                {
                    UserId = 3,
                    UserName = "test otro User",
                    Dni = 33333333,
                    Password = "123456",
                    Type = (int)UserType.Consultor,
                    IsActive = true
                }
            );
        }
    }
}
