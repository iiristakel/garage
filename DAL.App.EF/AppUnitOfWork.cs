using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        
        private readonly IRepositoryProvider _repositoryProvider;
        
        public IBillRepository Bills => _repositoryProvider.GetRepository<IBillRepository>();
        
        public IBillLineRepository BillLines =>_repositoryProvider.GetRepository<IBillLineRepository>();

        public IClientRepository Clients =>_repositoryProvider.GetRepository<IClientRepository>();
        
        public IClientGroupRepository ClientGroups =>_repositoryProvider.GetRepository<IClientGroupRepository>();
        
        public IPaymentRepository Payments =>_repositoryProvider.GetRepository<IPaymentRepository>();
        
        public IProductRepository Products =>_repositoryProvider.GetRepository<IProductRepository>();
        
        public IPaymentMethodRepository PaymentMethods =>_repositoryProvider.GetRepository<IPaymentMethodRepository>();
        
        public IProductForClientRepository ProductForClients =>_repositoryProvider.GetRepository<IProductForClientRepository>();
        
        public IWorkerRepository Workers =>_repositoryProvider.GetRepository<IWorkerRepository>();
        
        public IWorkObjectRepository WorkObjects =>_repositoryProvider.GetRepository<IWorkObjectRepository>();
        
        public IWorkerPositionRepository WorkerPositions =>_repositoryProvider.GetRepository<IWorkerPositionRepository>();
        
        public IWorkerOnObjectRepository WorkerOnObjects =>_repositoryProvider.GetRepository<IWorkerOnObjectRepository>();
        
        public IWorkerInPositionRepository WorkerInPositions =>_repositoryProvider.GetRepository<IWorkerInPositionRepository>();
        

        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new() =>
            _repositoryProvider.GetRepositoryForEntity<TEntity>();

        
        public AppUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _appDbContext = (dataContext as AppDbContext) ?? throw new ArgumentNullException(nameof(dataContext));
            _repositoryProvider = repositoryProvider;
        }

        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}