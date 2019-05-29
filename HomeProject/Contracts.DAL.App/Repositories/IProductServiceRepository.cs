using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductServiceRepository : IProductServiceRepository<DALAppDTO.ProductService>
    {
        Task<List<DALAppDTO.ProductService>> AllForClientProductAsync(int? productForClientId);
        Task<List<DALAppDTO.ProductService>> AllForWorkObjectAsync(int workObjectId);


    }

    public interface IProductServiceRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
    }
}