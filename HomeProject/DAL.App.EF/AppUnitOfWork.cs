﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : 
            base(dbContext, repositoryProvider)
        {
        }

                
        public IBillRepository Bills => _repositoryProvider.GetRepository<IBillRepository>();
        
        public IBillLineRepository BillLines =>_repositoryProvider.GetRepository<IBillLineRepository>();

        public IClientRepository Clients =>_repositoryProvider.GetRepository<IClientRepository>();
        
        public IClientGroupRepository ClientGroups =>_repositoryProvider.GetRepository<IClientGroupRepository>();
        
        public IPaymentRepository Payments =>_repositoryProvider.GetRepository<IPaymentRepository>();
        
        public IProductRepository Products =>_repositoryProvider.GetRepository<IProductRepository>();
        
        public IPaymentMethodRepository PaymentMethods =>_repositoryProvider.GetRepository<IPaymentMethodRepository>();
        
        public IProductForClientRepository ProductsForClients =>_repositoryProvider.GetRepository<IProductForClientRepository>();
        
        public IAppUserRepository AppUsers =>_repositoryProvider.GetRepository<IAppUserRepository>();
        
        public IWorkObjectRepository WorkObjects =>_repositoryProvider.GetRepository<IWorkObjectRepository>();
        
        public IAppUserPositionRepository AppUsersPositions =>_repositoryProvider.GetRepository<IAppUserPositionRepository>();
        
        public IAppUserOnObjectRepository AppUsersOnObjects =>_repositoryProvider.GetRepository<IAppUserOnObjectRepository>();
        
        public IAppUserInPositionRepository AppUsersInPositions =>_repositoryProvider.GetRepository<IAppUserInPositionRepository>();
        
        public IProductServiceRepository ProductsServices =>_repositoryProvider.GetRepository<IProductServiceRepository>();
    }
}