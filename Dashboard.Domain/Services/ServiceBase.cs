using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        protected bool status;
        protected string message;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual TEntity Add(TEntity obj)
        {
            return _repositoryBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public bool Remove(TEntity obj)
        {
            return _repositoryBase.Remove(obj);
        }

        public bool Update(TEntity obj)
        {
            return _repositoryBase.Update(obj);
        }


        public bool IsSuccessStatus()
        {
            return status;
        }
        public string GetMessage()
        {
            return message;
        }
    }
}
