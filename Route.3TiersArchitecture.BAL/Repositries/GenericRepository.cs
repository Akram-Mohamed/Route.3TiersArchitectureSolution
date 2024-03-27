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


        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            // _dbContext.Update(entity); // EF Core 3.1 NEW Feature
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            // _dbContext.Update(entity); // EF Core 3.1 NEW Feature
            return _dbContext.SaveChanges();
        }



        public int Delete(T entity)
        {
            //_dbContext.Set<T>().Remove(entity);
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        { 
            return  _dbContext.Set<T>().AsNoTracking().ToList(); 
        }

        public T GetSpecificEntity(int id)
          => _dbContext.Find<T>(id);




    }
}
