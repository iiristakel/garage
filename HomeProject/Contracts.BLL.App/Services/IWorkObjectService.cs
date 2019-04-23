using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App.Services
{
    public  interface IWorkObjectService: IBaseEntityService<WorkObject>, IWorkObjectRepository
    {
    }
}