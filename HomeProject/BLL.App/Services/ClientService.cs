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
            ServiceRepository = Uow.Clients;
        }

        public async Task<List<BLL.App.DTO.ClientWithProductsCount>> GetAllWithProductsCountAsync()
        {
            return (await Uow.Clients.GetAllWithProductsCountAsync())
                .Select(e => ClientMapper.MapFromDAL(e))
                .ToList();

        }
        
        public async Task<List<Client>> AllForClientGroupAsync(int? clientGroupId)
        {
            return (await Uow.Clients.AllForClientGroupAsync(clientGroupId))
                .Select(e => ClientMapper.MapFromDAL(e))
                .ToList();        
        }
    }
}