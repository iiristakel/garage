using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{

    public interface IProductForClientRepository : IProductForClientRepository<DALAppDTO.ProductForClient>
    {
        Task<List<DALAppDTO.ProductForClient>> AllForClientAsync(int? clientId);

    }

    public interface IProductForClientRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {

    }
    
}
