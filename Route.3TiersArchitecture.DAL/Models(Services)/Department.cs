using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public class Department
    {

        //[Key]
        public int Dept_Id { get; set; }//Primary Key
        [Required(ErrorMessage = "Code is Required Ya3m Enta :(--:(--")]//Not Accecpt Null
        public string Code { get; set; }//Department Number Shown To the user

        [Required(ErrorMessage = "Name is Required Ya3m Enta Tany :(--:(--")]//Not Accecpt Null
        public string Name { get; set; }

        [Display (Name="Date Of Creation ")]
        public DateTime DateOfCreation { get; set; }


    }
}
