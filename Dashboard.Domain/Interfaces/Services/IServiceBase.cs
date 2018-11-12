using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);

        bool IsSuccessStatus();
        string GetMessage();
    }
}
