using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public class Department : ModelBase
    {
       
        [Required(ErrorMessage = "Code is Required Ya3m Enta :(--:(--")]//Not Accecpt Null
        [MaxLength(5, ErrorMessage = "Max Length of Code is 5 Digits")]
        [MinLength(3, ErrorMessage = "Min Length of Code is 3 Digits")]
        public string Code { get; set; }//Department Number Shown To the user

        [Required(ErrorMessage = "Name is Required Ya3m Enta Tany :(--:(--")]//Not Accecpt Null
        [MaxLength(10, ErrorMessage = "Max Length of Name is 10 Chars")]
        [MinLength(3, ErrorMessage = "Min Length of Name is 3 Chars")]
        public string Name { get; set; }

        [Display (Name="Date Of Creation ")]

        public DateTime DateOfCreation { get; set; }



        //navigation property many
        public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
    }


}
