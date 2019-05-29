using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public  interface IProductForClientService
        : IBaseEntityService<BLLAppDTO.ProductForClient>, 
            IProductForClientRepository<BLLAppDTO.ProductForClient>
    {
        Task<List<BLLAppDTO.ProductForClient>> AllForClientAsync(int? clientId);

    }
}