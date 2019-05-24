using System;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;

namespace BLL.App
{
    public class AppBLL :  BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : 
            base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }
        public IBillService Bills => ServiceProvider.GetService<IBillService>();
        public IBillLineService BillLines => ServiceProvider.GetService<IBillLineService>();
        public IClientService Clients=> ServiceProvider.GetService<IClientService>();
        public IClientGroupService ClientGroups => ServiceProvider.GetService<IClientGroupService>();
        public IPaymentService Payments=> ServiceProvider.GetService<IPaymentService>();
        public IProductService Products=> ServiceProvider.GetService<IProductService>();
        public IPaymentMethodService PaymentMethods=> ServiceProvider.GetService<IPaymentMethodService>();
        public IProductForClientService ProductsForClients => ServiceProvider.GetService<IProductForClientService>();
        public IAppUserService AppUsers => ServiceProvider.GetService<IAppUserService>();
        public IWorkObjectService WorkObjects => ServiceProvider.GetService<IWorkObjectService>();
        public IAppUserPositionService AppUsersPositions => ServiceProvider.GetService<IAppUserPositionService>();
        public IAppUserOnObjectService AppUsersOnObjects => ServiceProvider.GetService<IAppUserOnObjectService>();
        public IAppUserInPositionService AppUsersInPositions => ServiceProvider.GetService<IAppUserInPositionService>();
        public IProductServiceService ProductsServices => ServiceProvider.GetService<IProductServiceService>();
    }
}