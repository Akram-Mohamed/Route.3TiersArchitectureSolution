using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public class DepartmentEditCreateDetailsModel
    {
        public Department Department { get; set; }
        public string ActionName { get; set; }
        public DepartmentEditCreateDetailsModel(Department _Department, string actionName)
        {
            Department = _Department;
            ActionName = actionName;
        }

    

    }
}
