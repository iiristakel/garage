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
    public class WorkObjectService  : BaseEntityService<WorkObject, IAppUnitOfWork>, IWorkObjectService
    {
        public WorkObjectService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<WorkObjectsDTO>> GetAllAsync()
        {
            return await Uow.WorkObjects.GetAllAsync();
        }
    }
}