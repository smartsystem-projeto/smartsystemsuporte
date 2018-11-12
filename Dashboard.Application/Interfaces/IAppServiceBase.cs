using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
    }
}
