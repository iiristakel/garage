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
        IAppUserRepository AppUsers { get; }
        IWorkObjectRepository WorkObjects { get; }
        IAppUserPositionRepository AppUsersPositions{ get; }
        IAppUserOnObjectRepository AppUsersOnObjects { get; }
        IAppUserInPositionRepository AppUsersInPositions { get; }
    }
}