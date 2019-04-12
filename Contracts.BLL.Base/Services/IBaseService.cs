using System;
using Contracts.Base;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
        Guid InstanceId { get; }
    }

    public interface IBaseEntityService<TEntity> : IBaseRepositoryAsync<TEntity>
        where TEntity : class, IBaseEntity<int>, new()
    {
        
    }
}