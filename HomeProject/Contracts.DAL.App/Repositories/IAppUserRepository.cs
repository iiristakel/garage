using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using Domain.Identity;

namespace Contracts.DAL.App.Repositories
{
    public interface IAppUserRepository: IBaseRepository<AppUser>
    {
        //add here custom methods
        Task<List<AppUser>> AllAsync();
    }
}