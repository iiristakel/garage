using System;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBillRepository Bills { get; }
        IBillLineRepository BillLines{ get; }
        IClientRepository Clients{ get; }
        IClientGroupRepository ClientGroups { get; }
        IPaymentRepository Payments{ get; }
        IProductRepository Products{ get; }
        IPaymentMethodRepository PaymentMethods{ get; }
        IProductForClientRepository ProductsForClients { get; }
        IWorkerRepository Workers { get; }
        IWorkObjectRepository WorkObjects { get; }
        IWorkerPositionRepository WorkersPositions{ get; }
        IWorkerOnObjectRepository WorkersOnObjects { get; }
        IWorkerInPositionRepository WorkersInPositions { get; }
    }
}