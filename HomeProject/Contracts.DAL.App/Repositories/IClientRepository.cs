using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IClientRepository : IClientRepository<DALAppDTO.Client>
    {
        Task<List<DALAppDTO.ClientWithProductsCount>> GetAllWithProductsCountAsync();
    }

    public interface IClientRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
    }
}