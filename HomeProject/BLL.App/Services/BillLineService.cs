using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;

namespace BLL.App.DTO
{
    public class BillLineService : BaseEntityService<BillLine, IAppUnitOfWork>, IBillLineService
    {
        public BillLineService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<BillLineDTO>> GetAllAsync()
        {
            return await Uow.BillLines.GetAllAsync();
        }
    }
}