using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

         IQueryable<Employee> GetEmployeesByAddress(string address);
        IQueryable<Employee>  SearchByName(string address);

    }
}
