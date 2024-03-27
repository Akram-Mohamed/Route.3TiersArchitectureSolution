using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Data.Configrations
{
    class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> DepartmentBuilder)
        {
            DepartmentBuilder.HasKey(D => D.Id);
            DepartmentBuilder.Property(D => D.Id).UseIdentityColumn(10, 10);

            DepartmentBuilder.Property(D => D.Name)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            //("Please ensure that you have entered your Surname"); ; 

            DepartmentBuilder.Property(D => D.Code)
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();

            DepartmentBuilder
                .HasMany(D => D.Employees)
                .WithOne(E => E.Department) 
                .HasForeignKey(E=> E.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
