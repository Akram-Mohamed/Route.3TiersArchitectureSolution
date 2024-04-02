using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Interface
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        IEnumerable<T> GetAll();
        T GetSpecificEntity(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
