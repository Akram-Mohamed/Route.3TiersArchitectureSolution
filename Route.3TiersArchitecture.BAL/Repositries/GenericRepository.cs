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
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected ApplicationDbContext _dbContext { get; }
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public  void Add(T entity)
           => _dbContext.Set<T>().Add(entity);
            // _dbContext.Update(entity); // EF Core 3.1 NEW Feature
            //return _dbContext.SaveChanges();
   

        public void Update(T entity)
          => _dbContext.Set<T>().Update(entity);
            // _dbContext.Update(entity); // EF Core 3.1 NEW Feature
            //return _dbContext.SaveChanges();



        public void Delete(T entity)
            =>_dbContext.Remove(entity);
            //_dbContext.Set<T>().Remove(entity);
           // return _dbContext.SaveChanges();
        

        ///public IEnumerable<T> GetAll()
        ///{
        ///    return _dbContext.Set<T>().AsNoTracking().ToList();
        ///}



        public virtual async Task< IEnumerable<T> > GetAllAsync()
        {
            if (typeof(T) == typeof(Employee) )
                return (IEnumerable<T>) await _dbContext.Set<Employee>().Include(E => E.Department).AsNoTracking().ToListAsync();
          

          return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task <T> GetSpecificEntity(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
             
        }
    }
}
