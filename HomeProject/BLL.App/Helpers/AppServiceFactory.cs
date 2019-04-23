using BLL.App.DTO;
using BLL.Base.Helpers;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            // Register all your custom services here!
            AddToCreationMethods<IBillLineService>(uow => new BillLineService(uow));
            AddToCreationMethods<IBillService>(uow => new BillService(uow));
            AddToCreationMethods<IClientGroupService>(uow => new ClientGroupService(uow));
            AddToCreationMethods<IClientService>(uow => new ClientService(uow));
            AddToCreationMethods<IPaymentMethodService>(uow => new PaymentMethodService(uow));
            AddToCreationMethods<IPaymentService>(uow => new PaymentService(uow));
            AddToCreationMethods<IProductForClientService>(uow => new ProductForClientService(uow));
            AddToCreationMethods<IProductService>(uow => new ProductService(uow));
            AddToCreationMethods<IWorkerInPositionService>(uow => new WorkerInPositionService(uow));
            AddToCreationMethods<IWorkerOnObjectService>(uow => new WorkerOnObjectService(uow));
            AddToCreationMethods<IWorkerPositionService>(uow => new WorkerPositionService(uow));
            AddToCreationMethods<IWorkerService>(uow => new WorkerService(uow));
            AddToCreationMethods<IWorkObjectService>(uow => new WorkObjectService(uow));

        }

    }
}