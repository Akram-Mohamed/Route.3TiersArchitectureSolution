using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {



        public ApplicationDbContext( DbContextOptions options) : base(options)
        {


        }
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //    => optionsBuilder.UseSqlServer("Server=.; Database = MVCApplicationG02; Trusted_Connection=True;"); // MultipleActiveResultSets = True


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }

    }
}
