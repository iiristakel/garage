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
    public class BillService 
        : BaseEntityService<BLL.App.DTO.Bill, DAL.App.DTO.Bill,
            IAppUnitOfWork>, IBillService
    {
        public BillService(IAppUnitOfWork uow) : base(uow, new BillMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Bill, Domain.Bill>();
        }

        public async Task<List<BLL.App.DTO.BillWithPaymentsCount>> GetAllWithPaymentsCountAsync()
        {
            return (await Uow.Bills.GetAllWithPaymentsCountAsync())
                .Select(e => BillMapper.MapFromDAL(e))
                .ToList();
        }

        public async Task<List<Bill>> AllForUserAsync(int userId)
        {
            return (await Uow.Bills
                    .AllForUserAsync(userId))
                .Select(e => BillMapper
                    .MapFromDAL(e)).ToList();
        }

        public async Task<Bill> FindForUserAsync(int id, int userId)
        {
            return BillMapper.MapFromDAL( await Uow.Bills.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Bills.BelongsToUserAsync(id, userId);
        }
    }
}