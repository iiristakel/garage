using System.Collections.Generic;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public  interface IWorkObjectService
        : IBaseEntityService<BLLAppDTO.WorkObject>, 
            IWorkObjectRepository<BLLAppDTO.WorkObject>
    {
    }
}