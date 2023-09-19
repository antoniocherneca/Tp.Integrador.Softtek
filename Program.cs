using Microsoft.EntityFrameworkCore;
using Tp.Integrador.Softtek.DataAccess;
using Tp.Integrador.Softtek.DataAccess.Repositories;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
            );
            //builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            //builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
            //builder.Services.AddScoped<IJobsRepository, JobsRepository>();
            //builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();

            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}