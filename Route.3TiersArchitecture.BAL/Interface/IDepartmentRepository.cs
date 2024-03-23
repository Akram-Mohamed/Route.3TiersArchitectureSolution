using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Interface
{

    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetSpecificDepartment(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);
    }
}
