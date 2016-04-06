using AgileCourtPOC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AgileCourtPOC.Domain.Entity;
using System.Data.Entity.Migrations;
using AgileCourtPOC.Infrastructure;

namespace AgileCourtPOC.Data.Repository
{
    class EntityFrameWorkSQLRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly AgileCourtDBContext _dbContext;

        public EntityFrameWorkSQLRepository(AgileCourtDBContext agileCourtDbContext )
        {
            _dbContext = agileCourtDbContext;
        }
        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public void Upsert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbContext.Set<TEntity>().AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }
    }
}
