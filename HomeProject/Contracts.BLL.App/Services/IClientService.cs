using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public  interface IClientService
        : IBaseEntityService<BLLAppDTO.Client>, 
            IClientRepository<BLLAppDTO.Client>
    {
        Task<List<BLLAppDTO.ClientWithProductsCount>> GetAllWithProductsCountAsync();

    }
}