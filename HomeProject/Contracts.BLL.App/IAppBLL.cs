using System;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        
        IBillService Bills { get; }
        IBillLineService BillLines{ get; }
        IClientService Clients{ get; }
        IClientGroupService ClientGroups { get; }
        IPaymentService Payments{ get; }
        IProductService Products{ get; }
        IPaymentMethodService PaymentMethods{ get; }
        IProductForClientService ProductsForClients { get; }
        IAppUserService AppUsers { get; }
        IWorkObjectService WorkObjects { get; }
        IAppUserPositionService AppUsersPositions{ get; }
        IAppUserOnObjectService AppUsersOnObjects { get; }
        IAppUserInPositionService AppUsersInPositions { get; }
        IProductServiceService ProductsServices { get; }


        // TODO: Public facing services
    }
}