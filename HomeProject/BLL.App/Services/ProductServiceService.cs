using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductServiceService
        : BaseEntityService<BLL.App.DTO.ProductService, DAL.App.DTO.ProductService,
            IAppUnitOfWork>, IProductServiceService
    {
        public ProductServiceService(IAppUnitOfWork uow) : base(uow, new ProductServiceMapper())
        {
            ServiceRepository = Uow.ProductsServices;

        }
        
        public async Task<List<BLL.App.DTO.ProductService>> AllForClientProductAsync(int? productForClientId)
        {
            return (await Uow.ProductsServices.AllForClientProductAsync(productForClientId))
                .Select(e => ProductServiceMapper.MapFromDAL(e))
                .ToList();
        }
        
        public async Task<List<BLL.App.DTO.ProductService>> AllForWorkObjectAsync(int workObjectId)
        {
            return (await Uow.ProductsServices.AllForWorkObjectAsync(workObjectId))
                .Select(e => ProductServiceMapper.MapFromDAL(e))
                .ToList();
        }

    }
}