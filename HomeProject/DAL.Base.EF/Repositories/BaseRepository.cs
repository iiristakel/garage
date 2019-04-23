using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity, TDbContext> : BaseRepository<TEntity, TDbContext, int>,
        IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
        where TDbContext : DbContext
    {
        public BaseRepository(TDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }


    public class BaseRepository<TEntity, TDbContext, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TDbContext: DbContext
        where TKey : IComparable
    {
        protected readonly DbContext RepositoryDbContext;
        protected readonly DbSet<TEntity> RepositoryDbSet;

        public BaseRepository(TDbContext repositoryDbContext)
        {
            RepositoryDbContext = repositoryDbContext;
            // get the dbset by type from db context
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
        }


        public virtual TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public virtual void Remove(params object[] id)
        {
            RepositoryDbSet.Remove(FindAsync(id).Result);
        }

        public virtual async Task<List<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        public List<TEntity> All()
        {
            return RepositoryDbSet.ToList();
        }

        public TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }
    }
}
