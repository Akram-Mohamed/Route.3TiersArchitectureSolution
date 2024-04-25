using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }
    public enum EmpType
    {
        FullTime = 1,
        PartTime = 2,
    }
    public class  Employee : ModelBase
    {

        public string Name { get; set; }

        public int? Age { get; set; }

        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool ISActive { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public EmpType EmpType { get; set; }

        public DateTime HiringDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeletable { get; set; } = false;

        public string ImageName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }




    }


}
