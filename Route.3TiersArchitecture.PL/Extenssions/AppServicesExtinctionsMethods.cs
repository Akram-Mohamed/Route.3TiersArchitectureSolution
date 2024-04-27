
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
using Route._3TiersArchitecture.PL.Services;
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

			///services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			///{
			///	options.Password.RequiredUniqueChars = 2;
			///	options.Password.RequireDigit = true;
			///	options.Password.RequireNonAlphanumeric = true; // @$%
			///	options.Password.RequireUppercase = true;
			///	options.Password.RequireLowercase = true;
			///	options.Password.RequiredLength = 5;
			///
			///	options.Lockout.AllowedForNewUsers = true;
			///	options.Lockout.MaxFailedAccessAttempts = 5;
			///	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(5);
			///	options.User.RequireUniqueEmail = true;
			///}).AddEntityFrameworkStores<ApplicationDbContext>();


			//services.ConfigureApplicationCookie(options =>
			//{
            //    options.LoginPath = "/Home/Index";
            //    options.LogoutPath = "/Account/Login";
			//	options.ExpireTimeSpan = TimeSpan.FromDays(5);
			//	options.AccessDeniedPath = "/Home/Error";
			//
			//});

			///services.AddAuthentication("Akram");
			///services.AddAuthentication(options =>
			///{
			///	//options.DefaultAuthenticateScheme = "Akram";
			///	options.DefaultAuthenticateScheme = "Identity.Application";
			///})
			///
			/// .AddCookie("Akram", options =>
			/// {
			///	 options.LoginPath = "Account/SignIn";
			///	 options.ExpireTimeSpan = TimeSpan.FromDays(9);
			///	 options.AccessDeniedPath = "/Home/Error";
			/// });

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddAuthentication();

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmailSender, EmailSender>();
			return services;
		}
	}
}
