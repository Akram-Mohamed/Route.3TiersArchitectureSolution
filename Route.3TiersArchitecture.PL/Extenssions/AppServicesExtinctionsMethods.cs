
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Data;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Helpers;
using System;
using System.Data.Common;



namespace Route._3TiersArchitecture.PL.Extenssions
{
    public static class AppServicesExtinctionsMethods
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddControllersWithViews();
            // Register Built-In Services Required by MVC
            //services.AddScoped<ApplicationDbContext>();
            //services.AddScoped<DbContextOptions<ApplicationDbContext>>();

            services.AddDbContext<ApplicationDbContext>(
                options =>
                {

                    //options.UseSqlServer(Configuration.GetSection("ConnectionString")["DefaultConnection"]);
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                },
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Scoped
                );
            services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => { })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LogoutPath = "/Account/SignIn";
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.AccessDeniedPath = "/Home/Error";

            });

            services.AddAuthentication("Akram");
            services.AddAuthentication(options =>
            {
                //options.DefaultAuthenticateScheme = "Akram";
                //options.DefaultAuthenticateScheme = "Identity.Application";
            })

             .AddCookie("Hamda", options =>
             {
                 options.LoginPath = "/Account/SignIn";
                 options.ExpireTimeSpan = TimeSpan.FromDays(9);
                 options.AccessDeniedPath = "/Home/Error";
             });

            //services.AddScoped<IUnitOfWork, IUnitOfWork>();
            // services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            // services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
