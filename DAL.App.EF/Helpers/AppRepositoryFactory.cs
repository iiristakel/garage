using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory
    {

        public AppRepositoryFactory()
        {
            // add to dictionary all the repo creation methods we might need!
            
            RepositoryCreationMethods.Add(typeof(IBillLineRepository), 
                dataContext => new BillLineRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IBillRepository), 
                dataContext => new BillRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IClientGroupRepository), 
                dataContext => new ClientGroupRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IClientRepository), 
                dataContext => new ClientRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IPaymentMethodRepository), 
                dataContext => new PaymentMethodRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IPaymentRepository), 
                dataContext => new PaymentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IProductForClientRepository), 
                dataContext => new ProductForClientRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IProductRepository), 
                dataContext => new ProductRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IWorkerInPositionRepository), 
                dataContext => new WorkerInPositionRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IWorkerOnObjectRepository), 
                dataContext => new WorkerOnObjectRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IWorkerPositionRepository), 
                dataContext => new WorkerPositionRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IWorkerRepository), 
                dataContext => new WorkerRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IWorkObjectRepository), 
                dataContext => new WorkObjectRepository(dataContext));
        }
    }
}