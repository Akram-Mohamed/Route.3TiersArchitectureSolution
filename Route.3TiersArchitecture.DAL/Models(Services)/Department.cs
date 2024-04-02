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
       
     
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }



        //navigation property many
        public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
    }


}
