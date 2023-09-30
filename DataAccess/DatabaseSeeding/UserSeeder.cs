using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Helpers;

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
                    UserName = "Juan Perez",
                    Dni = "11111111",
                    Email = "jperez@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("123456", "jperez@gmail.com"),
                    RoleId = 1,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 2,
                    UserName = "Maria Lopez",
                    Dni = "22222222",
                    Email = "mlopez@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("123456", "mlopez@gmail.com"),
                    RoleId = 2,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 3,
                    UserName = "Pedro Ramirez",
                    Dni = "33333333",
                    Email = "pramirez@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("123456", "pramirez@gmail.com"),
                    RoleId = 2,
                    IsDeleted = false
                }
            );
        }
    }
}
