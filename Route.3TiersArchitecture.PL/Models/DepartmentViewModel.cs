using Route._3TiersArchitecture.DAL.Models_Services_;
using System.Collections.Generic;
using System;

namespace Route._3TiersArchitecture.PL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
