using Microsoft.EntityFrameworkCore;
using RentRide.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Core
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _instances;
        private readonly Dictionary<Type, Type> _specificRepositories;
        private readonly DbContext _dbContext;



        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!_instances.ContainsKey(typeof(T)))
            {
                if(!_specificRepositories.TryGetValue(typeof(T), out var repositoryType))
                {
                    repositoryType = typeof(Repository<T>);
                }
                _instances.Add(typeof(T), Activator.CreateInstance(repositoryType,_dbContext));
            }

            return (IRepository<T>)_instances[typeof(T)];
        }

        protected void AddSpecificRepository<TEntity, TRepositoryType>()
        {
            _specificRepositories.Add(typeof(TEntity), typeof(TRepositoryType));
        }
    }
}
