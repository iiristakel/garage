﻿using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() 
            where TEntity : class, IBaseEntity, new();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}