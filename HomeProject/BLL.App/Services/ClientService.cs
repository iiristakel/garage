using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Client = BLL.App.DTO.Client;

namespace BLL.App.Services
{
    public class ClientService 
        : BaseEntityService<BLL.App.DTO.Client, DAL.App.DTO.Client,
            IAppUnitOfWork>, IClientService
    {
        public ClientService(IAppUnitOfWork uow) : base(uow, new ClientMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Client, Domain.Client>();
        }

        public async Task<List<BLL.App.DTO.ClientWithProductsCount>> GetAllWithProductsCountAsync()
        {
            return (await Uow.Clients.GetAllWithProductsCountAsync())
                .Select(e => ClientMapper.MapFromDAL(e))
                .ToList();

        }
    }
}