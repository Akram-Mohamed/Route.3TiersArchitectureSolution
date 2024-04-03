
using Route._3TiersArchitecture.DAL.Models_Services_;
using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Route._3TiersArchitecture.PL.Models
{

   
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required :(")]//Not Accecpt Null
        [MaxLength(50, ErrorMessage = "max length of name is 50 chars ")]
        [MinLength(5, ErrorMessage = "min length of name is 5 chars ")]
        public string Name { get; set; }
        [Range(22, 35)]
        public int? Age { get; set; }

        [RegularExpression(@"^\d{1,}-[A-Za-z0-9\s]+-[A-Za-z\s]+-[A-Za-z\s]+$"
                        , ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "IS Active")]
        public bool ISActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public EmpType EmpType { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        public IFormFile Image { get; set; }

        public string ImageName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
