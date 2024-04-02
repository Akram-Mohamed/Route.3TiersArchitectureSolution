using Route._3TiersArchitecture.DAL.Models_Services_;
using System;

namespace Route._3TiersArchitecture.PL.Models
{
    public class EmployeeResponseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? Age { get; set; }

        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool ISActive { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public string ImageName { get; set; }
   
   


    }
}
