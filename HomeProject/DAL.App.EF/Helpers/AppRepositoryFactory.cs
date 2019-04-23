using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {

        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }
        
        private void RegisterRepositories()
        {

            
            AddToCreationMethods<IBillLineRepository>( 
                dataContext => new BillLineRepository(dataContext));
            
            AddToCreationMethods<IBillRepository>( 
                dataContext => new BillRepository(dataContext));
            
            AddToCreationMethods<IClientGroupRepository>( 
                dataContext => new ClientGroupRepository(dataContext));
            
            AddToCreationMethods<IClientRepository>( 
                dataContext => new ClientRepository(dataContext));
            
            AddToCreationMethods<IPaymentMethodRepository>( 
                dataContext => new PaymentMethodRepository(dataContext));
            
            AddToCreationMethods<IPaymentRepository>( 
                dataContext => new PaymentRepository(dataContext));
            
            AddToCreationMethods<IProductForClientRepository>( 
                dataContext => new ProductForClientRepository(dataContext));
            
            AddToCreationMethods<IProductRepository>( 
                dataContext => new ProductRepository(dataContext));
            
            AddToCreationMethods<IWorkerInPositionRepository>( 
                dataContext => new WorkerInPositionRepository(dataContext));
            
            AddToCreationMethods<IWorkerOnObjectRepository>( 
                dataContext => new WorkerOnObjectRepository(dataContext));
            
            AddToCreationMethods<IWorkerPositionRepository>( 
                dataContext => new WorkerPositionRepository(dataContext));
            
            AddToCreationMethods<IWorkerRepository>( 
                dataContext => new WorkerRepository(dataContext));
            
            AddToCreationMethods<IWorkObjectRepository>( 
                dataContext => new WorkObjectRepository(dataContext));
        }
    }
}