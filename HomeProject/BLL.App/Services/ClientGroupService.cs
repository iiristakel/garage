using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ClientGroupService  
        : BaseEntityService<BLL.App.DTO.ClientGroup, DAL.App.DTO.ClientGroup,
            IAppUnitOfWork>, IClientGroupService
    {
        public ClientGroupService(IAppUnitOfWork uow) : base(uow, new ClientGroupMapper())
        {
            ServiceRepository = Uow.ClientGroups;

        }

        public async Task<List<BLL.App.DTO.ClientGroupWithClientCount>> GetAllWithClientCountAsync()
        {
            return (await Uow.ClientGroups.GetAllWithClientCountAsync())
                .Select(e => ClientGroupMapper.MapFromDAL(e))
                .ToList();

        }

        
    }
}