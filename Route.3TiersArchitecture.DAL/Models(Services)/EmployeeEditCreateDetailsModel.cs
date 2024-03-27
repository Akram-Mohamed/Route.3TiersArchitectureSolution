using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public class EmployeeEditCreateDetailsModel
    {
        public Employee Employee { get; set; }
        public string ActionName { get; set; }
        public EmployeeEditCreateDetailsModel(Employee employee, string actionName)
        {
            Employee = employee;
            ActionName = actionName;
        }

    

    }
}
