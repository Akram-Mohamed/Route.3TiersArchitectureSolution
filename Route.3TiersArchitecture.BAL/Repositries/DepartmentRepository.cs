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
    public class DepartmentRepository : IDepartmentRepository
    {

        private ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) // Ask CLR for Creating Object from ApplicationDbContext
        {
            //_dbContext = /*new ApplicationDbContext(new Microsoft.Entity FrameworkCore.DbContextOptionsDbContextOptions<ApplicationDbContext>>()
            _dbContext = dbContext;
        }



        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity); 
           return _dbContext.SaveChanges();
        }
        public int Update(Department entity) 
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Department GetSpecificDepartment(int id)
        {
            ///var department = _dbContext.Departments.Local.Where(D => D.Dept_Id == id).FirstOrDefault();
            ///if (department == null)
            ///    department = _dbContext.Departments.Where(D => D.Dept_Id == id).FirstOrDefault();
            ///return department; 
            //return _dbContext.Departments.Find(id);
            return _dbContext.Find<Department>(id); // EF Core 3.1 NEW Feature
        }

        public IEnumerable<Department> GetAll()
           => _dbContext.Departments.AsNoTracking().ToList();
        

    }
}
