using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Interface
{
    public interface IUnitOfWork: IDisposable
    {

        IGenericRepository<T> Repository<T> () where T : ModelBase;

        //public IEmployeeRepository EmployeeRepository { get; set; }
        //public IDepartmentRepository DepartmentRepository { get; set; }

        //public IGenericRepository<Department> DepartmentRepository { get; set; }
        int Complete();
    }
}
