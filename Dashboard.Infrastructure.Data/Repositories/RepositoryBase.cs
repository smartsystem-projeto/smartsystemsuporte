using Dashboard.Domain.Interfaces;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DashboardContext _db;

        public RepositoryBase(DashboardContext db)
        {
            _db = db;
        }

        public virtual TEntity Add(TEntity obj)
        {
            try
            {
                _db.Set<TEntity>().Add(obj);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

            return obj;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public bool Remove(TEntity obj)
        {
            try
            {
                _db.Set<TEntity>().Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Update(TEntity obj)
        {
            try
            {
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
