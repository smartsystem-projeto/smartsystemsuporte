using Dashboard.Application.Interfaces;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.AppServices
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public bool Add(TEntity obj)
        {
            return _serviceBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public bool Remove(TEntity obj)
        {
            return _serviceBase.Remove(obj);
        }

        public bool Update(TEntity obj)
        {
            return _serviceBase.Update(obj);
        }
    }
}
