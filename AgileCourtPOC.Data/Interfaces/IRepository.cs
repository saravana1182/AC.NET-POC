using AgileCourtPOC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Data.Interfaces
{
    public interface IRepository<TEntity,TKey> where TEntity : Entity<TKey>
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity,bool>> predicate);
        TEntity Get(TKey id);
        void Upsert(TEntity entity);
        void Delete(TEntity entity);
    }


}

       

