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
    public class EmployeeConfigrations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employee_builder)
        {
            employee_builder.HasKey(E => E.Emp_Id);

            employee_builder.Property(E =>  E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            employee_builder.Property(E => E.Address).IsRequired();
            employee_builder.Property(E => E.Salary).HasColumnType("decimal(12,2)");
            employee_builder.Property(E => E.Ge)


        }
    }
}
