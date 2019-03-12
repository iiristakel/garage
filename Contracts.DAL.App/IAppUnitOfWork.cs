using System;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IBillRepository Bills { get; }
        IBillLineRepository BillLines{ get; }
        IClientRepository Clients{ get; }
        IClientGroupRepository ClientGroups { get; }
        IPaymentRepository Payments{ get; }
        IProductRepository Products{ get; }
        IPaymentMethodRepository PaymentMethods{ get; }
        IProductForClientRepository ProductForClients { get; }
        IWorkerRepository Workers { get; }
        IWorkObjectRepository WorkObjects { get; }
        IWorkerPositionRepository WorkerPositions{ get; }
        IWorkerOnObjectRepository WorkerOnObjects { get; }
        IWorkerInPositionRepository WorkerInPositions { get; }
    }
}