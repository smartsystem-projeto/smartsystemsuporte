using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
    }
}
