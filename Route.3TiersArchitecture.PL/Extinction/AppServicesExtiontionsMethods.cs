using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Data;
using Route._3TiersArchitecture.PL.Helppers;

namespace MVC.Session03.PL.Extinction
{
    public static class AppServicesExtinctionsMethods
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddControllersWithViews();
            //services.AddScoped<AppDbContext>();
            //services.AddScoped<DbContextOptions<AppDbContext>>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddAutoMapper(M => M.AddProfile(new MapperConfiguration()));
            return services;
        }
    }
}
