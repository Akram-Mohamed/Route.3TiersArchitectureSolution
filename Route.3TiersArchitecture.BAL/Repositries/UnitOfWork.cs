using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.DAL.Data;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.BAL.Repositries
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        //public IEmployeeRepository EmployeeRepository { get; set; }
        //public IDepartmentRepository DepartmentRepository { get; set; }

        //private Dictionary<string, IGenericRepository<ModelBase>> _repositoties;
        private Hashtable _repositoties; // not affriad from boxing and unboxing

        public UnitOfWork(ApplicationDbContext dbContext) // Ask CLR for Creating Object from 'DbContext'
        {
            //EmployeeRepository = new EmployeeRepository(dbContext);  //DepartmentRepository = new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

   

        public IGenericRepository<T> Repository<T>() /*Repository<Employee>()*/ where T : ModelBase
        {
            //var key = typeof(T).Name; // Employee
            // return new GenericRepository<T>(_dbContext) as IGenericRepository<T>;


            var key = typeof(T).Name; // Employee
            if (!_repositoties.ContainsKey(key))
            {
                ///IGenericRepository<T> repository; 
                ///if (key == nameof(Employee))
                ///   repository = new EmployeeRepository (_dbContext);
                ///
                ///else
                ///repository = new GenericRepository<T>(_dbContext);
                ///  _repositoties.Add(key, repository);
                ///  

                if (!_repositoties.ContainsKey(key))
                {
                    if (key == nameof(Employee))
                    {
                        var repository = new EmployeeRepository(_dbContext); 
                        _repositoties.Add(key, repository);
                    }
                    else
                    {
                        var repository = new GenericRepository<T>(_dbContext);
                        _repositoties.Add(key, repository);
                    }

                  
                }
            }
                return _repositoties[key] as IGenericRepository<T>;



        }
            public int Complete()
            {
                return _dbContext.SaveChanges();
            }

            public void Dispose()
            {
                _dbContext.Dispose(); //Close Connection 
            }


        }
    }
