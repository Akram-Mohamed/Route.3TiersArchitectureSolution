using Microsoft.EntityFrameworkCore;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.DAL.Data;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Repositries
{

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext)  // Ask CLR for Creating Object from DbContext
            : base(dbContext)
        {

        }


        public  IQueryable<Employee>  GetEmployeesByAddress(string address)
        {
            return  _dbContext.Employees.Where(E => string.Equals(E.Address, address, StringComparison.OrdinalIgnoreCase));
        }
        public IQueryable<Employee> SearchByName(string Name)
        {
            return _dbContext.Employees.Where(E => E.Name.ToLower().Contains(Name.ToLower()));

            ///=> _dbContext.Employees
            ///    .Where(
            ///           E => string.Equals(E.Name, Name, StringComparison.OrdinalIgnoreCase)
            ///          );

        }



       // public override IEnumerable<Employee> GetAllAsync()
       // => _dbContext.Set<Employee>().Include(E => E.Department).AsNoTracking().ToList();

        public override async Task<IEnumerable<Employee> > GetAllAsync()
          => await _dbContext.Set<Employee>().Include(E => E.Department).AsNoTracking().ToListAsync();


        #region OLD Implement

        /*
       private ApplicationDbContext _EmployeeDbContext { get; }
       public EmployeeRepository(ApplicationDbContext dbContext)
       {
           _EmployeeDbContext = dbContext;
       }


       public int Add(Employee entity)
       {
           _EmployeeDbContext.Add(entity);
           return _EmployeeDbContext.SaveChanges();
       }

       public int Delete(Employee entity)
       {
           _EmployeeDbContext.Remove(entity);
           return _EmployeeDbContext.SaveChanges();
       }

       public IEnumerable<Employee> GetAll()
        => _EmployeeDbContext.Employees.AsNoTracking().ToList();

       public Employee GetSpecificEntity(int id)
        => _EmployeeDbContext.Find<Employee>(id);


       public int Update(Employee entity)
       {
           _EmployeeDbContext.Update(entity);
           return _EmployeeDbContext.SaveChanges();
       }

       public IEnumerable<Employee> GetEmployeesByAddress(string address)
       {
           throw new NotImplementedException();
       }

           */

        #endregion


    }
}
