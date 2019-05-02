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
    public class BillLineService 
        : BaseEntityService<BLL.App.DTO.BillLine, DAL.App.DTO.BillLine,
            IAppUnitOfWork>, IBillLineService
    {
        public BillLineService(IAppUnitOfWork uow) : base(uow, new BillLineMapper())
        {
            ServiceRepository = Uow.BillLines;
        }

        public async Task<List<DTO.BillLine>> GetAllAsync()
        {
            return (await Uow.BillLines.AllAsync())
                .Select(e => BillLineMapper.MapFromDAL(e))
                .ToList();
        }

        public async Task<List<BillLine>> AllForUserAsync(int userId)
        {
            return (await Uow.BillLines
                    .AllForUserAsync(userId))
                .Select(e => BillLineMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<BillLine> FindForUserAsync(int id, int userId)
        {
            return BillLineMapper.MapFromDAL( await Uow.BillLines.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.BillLines.BelongsToUserAsync(id, userId);
        }
    }
}